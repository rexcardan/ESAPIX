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

#endregion

namespace ESAPIX.AppKit.Overlay
{
    /// <summary>
    /// Interaction logic for SelectPatient.xaml, helps to pick a patient when using a StandAloneContext. Will display at the top of the designed window
    /// </summary>
    public partial class SelectPatient : Page, INotifyPropertyChanged
    {
        private readonly StandAloneContext _app;
        private readonly Dispatcher _disp;
        private string _selCourse;

        private string _selectedPlanItem;
        private List<PatientSummary> _summaries;

        public SelectPatient(StandAloneContext app)
        {
            _disp = Dispatcher.CurrentDispatcher;
            InitializeComponent();
            _app = app;
            //Preload summaries
            LoadSummaries();
            DataContext = this;
            patientContextMenu.Visibility = Visibility.Visible;
            hideContextButton.Visibility = Visibility.Visible;
            showContextButton.Visibility = Visibility.Collapsed;
            Courses = new ObservableCollection<string>();
            PlanItems = new ObservableCollection<string>();
            SaveContextCommand = new DelegateCommand(() =>
            {
               ContextIO.SaveToFile(_app);
            });
        }

        private async void LoadSummaries()
        {
            patientId.IsEnabled = false;
            await Task.Run(() =>
            {
                UpdateStatus("Caching Summaries...");
                _summaries = _app.Application.PatientSummaries.ToList();
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
                _selCourse = value;
                var plans = new List<string>();
                var course = _app.Patient.Courses.FirstOrDefault(c => c.Id == _selCourse);
                _app.SetCourse(course);
                UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName,
                    _app.Patient.FirstName, "Loading plans...."));
                plans = course != null ? course.PlanSetups.Select(ps => ps.Id).ToList() : new List<string>();
                UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName,
                    _app.Patient.FirstName, _app.Patient.Id));
                //Update UI
                _disp.Invoke(() =>
                {
                    PlanItems.Clear();
                    plans.ForEach(PlanItems.Add);
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
                    _app.Thread.InvokeAsync(() =>
                    {
                        var plan = _app.Course.PlanSetups.FirstOrDefault(ps => ps.Id == value);
                        _app.SetPlanSetup(plan);
                    });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateStatus(string p)
        {
            Status = p;
            OnPropertyChanged("Status");
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

        public ObservableCollection<PatientSummary> Suggestions { get; set; } = new ObservableCollection<PatientSummary>();

        private async void patientId_DropDownClosed(object sender, EventArgs e)
        {
            //Mode up selected
            var patientSummary = patientId.SelectedItem as PatientSummary;
            patientSummary = patientSummary ?? Suggestions.FirstOrDefault();
            await ModeUpSelected(patientSummary);
        }

        private async Task ModeUpSelected(PatientSummary patientSummary)
        {
            //Load text correctly
            if (patientSummary != null)
            {
                patientId.Text = $"({patientSummary.Id}) {patientSummary.LastName}, {patientSummary.FirstName}";
                if (patientSummary.Id != _app.Patient?.Id)
                {
                    //Close last patient
                    await Task.Run(() =>
                    {
                        if (_app.Patient != null)
                        {
                            Debug.WriteLine($"Closing patient {_app.Patient.LastName}");
                            _app.ClosePatient();
                        }
                    });

                    //Mode up selected
                    if (_app.SetPatient(patientSummary.Id))
                    {
                        Courses.Clear();
                        var courseNames = _app.Patient.Courses.Select(c => c.Id).ToList();
                        courseNames.ForEach(Courses.Add);

                        SelectedCourse = Courses.FirstOrDefault();
                        OnPropertyChanged("Courses");
                        OnPropertyChanged("SelectedCourse");
                        OnPropertyChanged("Status");
                    }
                }
            }
        }

        private void patientId_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Back)
            {
                SearchForPatientCandidates(patientId.Text);
            }
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                var patientSummary = Suggestions.FirstOrDefault();
                ModeUpSelected(patientSummary);
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