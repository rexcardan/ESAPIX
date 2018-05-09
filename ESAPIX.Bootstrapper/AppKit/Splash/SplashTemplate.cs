using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ESAPIX.Bootstrapper.AppKit.Splash
{
    /// <summary>
    /// Interaction logic for SplashTempate.xaml
    /// </summary>
    public abstract class SplashTemplate : UserControl
    {
        public event EventHandler Finished;

        public virtual void RaiseFinished(EventArgs e)
        {
            EventHandler handler = Finished;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
