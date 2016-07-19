
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
using VMS.TPS.Common.Model.API;

namespace ESAPIX.AppKit.Overlay
{
    /// <summary>
    /// Interaction logic for SelectPatient.xaml
    /// </summary>
    public partial class SelectPatient : Page, INotifyPropertyChanged
    {
        public SelectPatient(StandAloneContext app)
        {
            InitializeComponent();
            _app = app;
            this.DataContext = this;
            this.patientContextMenu.Visibility = System.Windows.Visibility.Visible;
            this.hideContextButton.Visibility = System.Windows.Visibility.Visible;
            this.showContextButton.Visibility = System.Windows.Visibility.Collapsed;
            Courses = new ObservableCollection<Course>();
            PlanItems = new ObservableCollection<PlanSetup>();
        }

        public string PatientId { get; set; }
        public string Status { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<PlanSetup> PlanItems { get; set; }
        private Course _selCourse;
        private StandAloneContext _app;

        public Course SelectedCourse
        {
            get { return _selCourse; }
            set
            {
                _selCourse = value;
                PlanItems.Clear();
                _selCourse.PlanSetups.ToList().ForEach(PlanItems.Add);
            }
        }

        private PlanSetup _selectedPlanItem;
        public PlanSetup SelectedPlanItem
        {
            get { return _selectedPlanItem; }
            set
            {
                _selectedPlanItem = value;
                _app.SetExternalPlanSetup(value as ExternalPlanSetup);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("Searching...");
            await UpdatePatient();
        }

        public async Task UpdatePatient()
        {
            if (_app != null)
            {
                await _app.Thread.InvokeAsync(() =>
                {
                    if (_app.Patient != null) { _app.ClosePatient(); }
                    if (_app.SetPatient(PatientId))
                    {
                        if (_app.Patient != null)
                        {
                            UpdateStatus(string.Format("Current Context is {0}, {1} | {2}", _app.Patient.LastName, _app.Patient.FirstName, _app.Patient.Id));
                            Courses.Clear();

                            _app.Patient.Courses
                                .ToList()
                                .ForEach(Courses.Add);
                            SelectedCourse = Courses.FirstOrDefault();
                            OnPropertyChanged("Courses");
                            OnPropertyChanged("SelectedCourse");
                            OnPropertyChanged("Status");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Patient not found!");
                    }
                });
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
    }
}
