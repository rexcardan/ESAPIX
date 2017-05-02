using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using ESAPIX.Interfaces;
using ESAPIX.Facade.API;
using System.Diagnostics;
using Prism.Commands;

namespace ESAPIX.AppKit.Overlay
{
    /// <summary>
    /// Interaction logic for SelectPatient.xaml, helps to pick a patient when using a StandAloneContext. Will display at the top of the designed window
    /// </summary>
    public partial class SelectPatient : Page, INotifyPropertyChanged
    {
        Dispatcher _disp;

        public SelectPatient(StandAloneContext app)
        {
            _disp = Dispatcher.CurrentDispatcher;
            InitializeComponent();
            _app = app;
            this.DataContext = this;
            this.patientContextMenu.Visibility = System.Windows.Visibility.Visible;
            this.hideContextButton.Visibility = System.Windows.Visibility.Visible;
            this.showContextButton.Visibility = System.Windows.Visibility.Collapsed;
            Courses = new ObservableCollection<string>();
            PlanItems = new ObservableCollection<string>();
            SearchCommand = new DelegateCommand(async () =>
            {
                UpdateStatus("Searching...");
                await UpdatePatient();
            });
        }
        public string Status { get; set; }
        public ObservableCollection<string> Courses { get; set; }
        public ObservableCollection<string> PlanItems { get; set; }
        private string _selCourse;
        private StandAloneContext _app;

        public string SelectedCourse
        {
            get { return _selCourse; }
            set
            {
                _selCourse = value;
                var plans = new List<string>();
                Action asyncA = new Action(async () =>
                {
                    //Call VMS
                    await Task.Run(() =>
                    {
                        var course = _app.Patient.Courses.FirstOrDefault(c => c.Id == _selCourse);
                        _app.SetCourse(course);
                        UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName, _app.Patient.FirstName, "Loading plans...."));
                        plans = course != null ? course.PlanSetups.Select(ps => ps.Id).ToList() : new List<string>();
                        UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName, _app.Patient.FirstName, _app.Patient.Id));
                    });

                    //Update UI
                    _disp.Invoke(new Action(() =>
                    {
                        PlanItems.Clear();
                        plans.ForEach(PlanItems.Add);
                        SelectedPlanItem = PlanItems.FirstOrDefault();
                        OnPropertyChanged("SelectedPlanItem");
                        OnPropertyChanged("SelectedCourse");

                    }));

                });
                asyncA.Invoke();
            }
        }

        private string _selectedPlanItem;
        public string SelectedPlanItem
        {
            get { return _selectedPlanItem; }
            set
            {
                _selectedPlanItem = value;
                if (value != null)
                {
                    _app.Thread.InvokeAsync(() =>
                    {
                        var plan = _app.Course.PlanSetups.FirstOrDefault(ps => ps.Id == value);
                        _app.SetPlanSetup(plan);
                    });
                }
            }
        }

        public async Task UpdatePatient()
        {
            try
            {
                if (_app != null)
                {
                    string id = "";
                    await _disp.InvokeAsync(() =>
                    {
                        id = patientId.Text;
                    });
                    //Close last patient
                    await Task.Run(() =>
                   {
                       if (_app.Patient != null && _app.Patient.IsLive)
                       {
                           Debug.WriteLine($"Closing patient {_app.Patient.LastName}");
                           _app.ClosePatient();
                       }
                   });
                    var foundPatient = await Task.Run(() =>
                    {
                        if (_app.SetPatient(id))
                        {
                            Debug.WriteLine($"Found patient {id}");
                            UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName, _app.Patient.FirstName, _app.Patient.Id));
                            return true;
                        }
                        else
                        {
                            Debug.WriteLine($"Couldn't find patient {patientId.Text}");
                            UpdateStatus("Patient not found!");
                            return false;
                        }
                    });

                    if (foundPatient)
                    {
                        var courseNames = _app.Patient.Courses.Select(c => c.Id).ToList();

                        Courses.Clear();
                        courseNames.ForEach(Courses.Add);

                        SelectedCourse = Courses.FirstOrDefault();
                        OnPropertyChanged("Courses");
                        OnPropertyChanged("SelectedCourse");
                        OnPropertyChanged("Status");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void UpdateStatus(string p)
        {
            Status = p;
            OnPropertyChanged("Status");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ShowPatientContext_Click(object sender, RoutedEventArgs e)
        {
            this.patientContextMenu.Visibility = System.Windows.Visibility.Visible;
            this.hideContextButton.Visibility = System.Windows.Visibility.Visible;
            this.showContextButton.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void HidePatientContext_Click(object sender, RoutedEventArgs e)
        {
            this.patientContextMenu.Visibility = System.Windows.Visibility.Collapsed;
            this.hideContextButton.Visibility = System.Windows.Visibility.Collapsed;
            this.showContextButton.Visibility = System.Windows.Visibility.Visible;
        }

        public DelegateCommand SearchCommand { get; set; }
    }
}

