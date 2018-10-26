#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Prism.Commands;
using ESAPIX.Common;
using ESAPIX.Helpers;
using ESAPIX.Common.Args;
using VMS.TPS.Common.Model.API;
using F = ESAPIX.Facade.API;
using ESAPIX.Helpers.Strings;

#endregion

namespace ESAPIX.AppKit.Overlay
{
    /// <summary>
    /// Interaction logic for SelectPatient.xaml, helps to pick a patient when using a StandAloneContext. Will display at the top of the designed window
    /// </summary>
    public partial class SelectPatient : Page, INotifyPropertyChanged
    {
        private readonly Dispatcher _disp;
        private string _selCourse;

        private string _selectedPlanItem;
        private List<F.PatientSummary> _summaries;

        public SelectPatient()
        {
            _disp = Dispatcher.CurrentDispatcher;
            InitializeComponent();
            //Preload summaries
            LoadSummaries();
            DataContext = this;
            patientContextMenu.Visibility = Visibility.Visible;
            hideContextButton.Visibility = Visibility.Visible;
            showContextButton.Visibility = Visibility.Collapsed;
            Courses = new ObservableCollection<string>();
            PlanItems = new ObservableCollection<string>();
            SaveContextCommand = new DelegateCommand(async () =>
            {
                await AppComThread.Instance.ExecuteAsync(sc =>
                {
                    ContextIO.SaveToFile(sc);
                });
            });
        }

        private async void LoadSummaries()
        {
            patientId.IsEnabled = false;
            await AppComThread.Instance.InvokeAsync(async () =>
            {
                UpdateStatus("Caching Summaries...");
                _summaries = await AppComThread.Instance.GetValueAsync(sac =>
                {
                    return sac.Application.PatientSummaries.Select(p => new F.PatientSummary()
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                    }).ToList();
                });
                UpdateStatus("");
            });
            patientId.IsEnabled = true;
        }

        public string Status { get; set; }
        public ObservableCollection<string> Courses { get; set; }
        public ObservableCollection<string> PlanItems { get; set; }

        public string SelectedCourse
        {
            get { return _selCourse; }
            set
            {
                var (coursePlans, lastName, firstName, id) = AppComThread.Instance.GetValue((sc) =>
                {
                    _selCourse = value;
                    var plans = new List<string>();
                    var course = sc.Patient.Courses.FirstOrDefault(c => c.Id == _selCourse);
                    sc.SetCourse(course);
                    //Get to string for dispatcher
                    var (lastName2, firstName2, id2) = (sc.Patient.LastName, sc.Patient.FirstName, sc.Patient.Id); 
                    plans = course != null ? course.PlanSetups.Select(ps => ps.Id).ToList() : new List<string>();
                    return (plans, lastName2, firstName2, id2);
                });

                UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", lastName,
                     firstName, id));
                //Update UI
                _disp.Invoke(() =>
                {
                    PlanItems.Clear();
                    coursePlans.ForEach(PlanItems.Add);
                    SelectedPlanItem = PlanItems.FirstOrDefault();
                    OnPropertyChanged("SelectedPlanItem");
                    OnPropertyChanged("SelectedCourse");
                });
            }
        }

        public string SelectedPlanItem
        {
            get { return _selectedPlanItem; }
            set
            {
                _selectedPlanItem = value;
                if (value != null)
                    AppComThread.Instance.ExecuteAsync((sc) =>
                    {
                        var plan = sc.Course.PlanSetups.FirstOrDefault(ps => ps.Id == value);
                        sc.SetPlanSetup(plan);
                    });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateStatus(string p)
        {
            _disp.Invoke(() =>
            {
                Status = p;
                OnPropertyChanged("Status");
            });
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowPatientContext_Click(object sender, RoutedEventArgs e)
        {
            patientContextMenu.Visibility = Visibility.Visible;
            hideContextButton.Visibility = Visibility.Visible;
            showContextButton.Visibility = Visibility.Collapsed;
        }

        private void HidePatientContext_Click(object sender, RoutedEventArgs e)
        {
            patientContextMenu.Visibility = Visibility.Collapsed;
            hideContextButton.Visibility = Visibility.Collapsed;
            showContextButton.Visibility = Visibility.Visible;
        }

        public DelegateCommand SaveContextCommand { get; set; }

        #region AUTOCOMPLETE FUNCTIONS
        private void SearchForPatientCandidates(string inputText)
        {
            Suggestions.Clear();
            var candidates = _summaries.Select(s => new
            {
                s,
                IdDistance = Levenshtein.ComputeDistance(s.Id.ToUpper(), inputText.ToUpper()),
                LastNameDistance = Levenshtein.ComputeDistance(s.LastName.ToUpper(), inputText.ToUpper()),
                FullNameDistance = Levenshtein.ComputeDistance($"{s.LastName.ToUpper()}, {s.FirstName.ToUpper()}", inputText.ToUpper()),
            })
            .Select(s => new { s.s, Distance = Math.Min(Math.Min(s.IdDistance, s.FullNameDistance), s.LastNameDistance) })
            .OrderBy(s => s.Distance)
            .Where(s => s.Distance < 5)
            .OrderBy(s => s.Distance)
            .Take(5).ToList();
            candidates.ForEach(c => Suggestions.Add(c.s));
        }

        public ObservableCollection<F.PatientSummary> Suggestions { get; set; } = new ObservableCollection<F.PatientSummary>();

        private async void patientId_DropDownClosed(object sender, EventArgs e)
        {
            //Mode up selected
            var patientSummary = patientId.SelectedItem as F.PatientSummary;
            patientSummary = patientSummary ?? Suggestions.FirstOrDefault();
            await ModeUpSelected(patientSummary);
        }

        private async Task ModeUpSelected(F.PatientSummary patientSummary)
        {
            //Load text correctly
            if (patientSummary != null)
            {
                patientId.Text = $"({patientSummary.Id}) {patientSummary.LastName}, {patientSummary.FirstName}";
                if (patientSummary.Id != AppComThread.Instance.GetValue(sc => sc.Patient?.Id))
                {
                    //Close last patient
                    await AppComThread.Instance.ExecuteAsync((sc) =>
                    {
                        if (sc.Patient != null)
                        {
                            Debug.WriteLine($"Closing patient {sc.Patient.LastName}");
                            sc.ClosePatient();
                        }
                    });


                    //Mode up selected (if patient exists)
                    if (AppComThread.Instance.GetValue(sc => sc.SetPatient(patientSummary.Id)))
                    {
                        Courses.Clear();
                        var courseNames = AppComThread.Instance.GetValue(sc =>
                        {
                            return sc.Patient.Courses.Select(c => c.Id).ToList();
                        });
                        courseNames.ForEach(Courses.Add);
                        SelectedCourse = Courses.FirstOrDefault();
                        OnPropertyChanged("Courses");
                        OnPropertyChanged("SelectedCourse");
                        OnPropertyChanged("Status");
                    }
                }
            }
        }

        private async void patientId_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Back)
            {
                SearchForPatientCandidates(patientId.Text);
            }
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                var patientSummary = Suggestions.FirstOrDefault();
                await ModeUpSelected(patientSummary);
            }
        }

        private void patientId_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            SearchForPatientCandidates(patientId.Text + e.Text);
            patientId.IsDropDownOpen = true;
        }
        #endregion
    }
}