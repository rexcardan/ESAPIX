using ESAPIX.Extensions;
using Microsoft.Win32;
using System.IO;

namespace ESAPIX.Common.Args
{
    public class ContextIO
    {
        public static void SaveToFile(StandAloneContext app)
        {
            var contextString = ArgumentBuilder.Build(app);
            var dlg = new SaveFileDialog();
            dlg.FileName = "context.txt"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension

            // Show open file dialog box
            var result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                var filename = dlg.FileName;
                File.WriteAllText(filename, contextString);
            }
        }

        public static string[] ReadArgsFromFile(string filePath)
        {
            return File.ReadAllText(filePath).SplitOnWhiteSpace();
        }
    }
}
