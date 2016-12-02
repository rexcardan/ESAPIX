using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ESAPIX.AppKit.Splash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        Storyboard Showboard;
        private delegate void ShowDelegate();

        public SplashScreen(string softLabel = "")
        {
            this.InitializeComponent();
            this.SoftLabel.Text = softLabel;
            Showboard = this.Resources["Storyboard1"] as Storyboard;
        }

        public void Animate()
        {
            BeginStoryboard(Showboard);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Showboard.Completed += Showboard_Completed;
            BeginStoryboard(Showboard);
        }

        void Showboard_Completed(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}