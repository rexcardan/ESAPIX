using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESAPIX.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Provides a file chooser
        /// </summary>
        /// <returns>the path to the file chosen or null for no file selected</returns>
        public static string ChooseFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Protocol (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                return filename;
            }
            return null;
        }

        /// <summary>
        /// Provides a file folder chooser
        /// </summary>
        /// <returns>the path to the folder chosen or null for no folder selected</returns>
        public static string ChooseFolder()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return null;
        }

        public static void LaunchFile(string path)
        {
            Process.Start("Explorer.exe", $"/e, /root, \"{path}\"");
        }
    }
}
