using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ESAPIX.Common
{
    /// <summary>
    /// Helpful methods to get UI responses using console
    /// </summary>
    public class ConsoleUI
    {
        public ConsoleUI()
        {
            PromptColor = ConsoleColor.Yellow;
            ProgressBarColor = ConsoleColor.Green;
            ErrorColor = ConsoleColor.Red;
        }

        public ConsoleColor PromptColor { get; set; }
        public ConsoleColor ProgressBarColor { get; set; }
        public ConsoleColor ErrorColor { get; set; }
        /// <summary>
        /// Gets yes or no response. Returns true if yes
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public bool GetYesNoResponse(string prompt = "Yes (Y) or no (N)?")
        {
            Console.WriteLine(prompt, PromptColor);
            var key = Console.ReadKey().Key;
            Console.WriteLine(string.Empty);
            return key == ConsoleKey.Y;
        }

        /// <summary>
        /// Gets a response from a list of string possible answers. Returns the string the user selects
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public string GetStringResponse(string[] answers)
        {
            Console.ForegroundColor = PromptColor;
            Console.WriteLine("Which would you like?");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            answers
            .Select((p, i) => string.Format("{0} - {1}", i, p))
            .ToList()
            .ForEach(a => Console.WriteLine(a, PromptColor));
            if (answers.Length == 0)
            {
                Console.WriteLine("-Nothing found");
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("");

            Console.ForegroundColor = PromptColor;
            var result = GetIntInput("");

            if (answers.Length >= result)
            {
                Console.Write(" - " + answers[result]);
                Console.WriteLine("");
                Console.ResetColor();
                return answers[result];
            }

            Console.WriteLine("");
            Console.ResetColor();
            WriteError($"Not a valid selection, must be less than {answers.Length}");
            return GetStringResponse(answers);
        }

        public int GetSelection<T>(IEnumerable<T> options, Func<T, string> TtoString)
        {
            var responses = options.Select(o => TtoString(o)).ToArray();
            return GetResponse(responses);
        }

        /// <summary>
        /// Allows the selection of multiple options
        /// </summary>
        /// <typeparam name="T">the type of option</typeparam>
        /// <param name="options">the available options</param>
        /// <param name="TtoString">a transform to convert an option to a string for selection</param>
        /// <returns>the indicies of the options chosen</returns>
        public int[] GetMultipleSelection<T>(IEnumerable<T> options, Func<T, string> TtoString)
        {
            var responses = options.Select(o => TtoString(o)).ToArray();
            int i = 0;
            foreach (var option in options)
            {
                try
                {
                    Write($"{i}: {TtoString(option)}");
                }
                catch (Exception e)
                {
                    WriteError(e.Message);
                }
                i++;
            }
            return GetMultipleIntInput("Which do you want (eg. 1-4,7,9,15-22)?");
        }

        public double GetDoubleInput(string prompt)
        {
            double response = double.NaN;
            if (!string.IsNullOrEmpty(prompt))
                WritePrompt(prompt);
            var valid = false;
            while (!valid)
            {
                var possibleInt = Console.ReadLine();

                if (!double.TryParse(possibleInt, out response))
                {
                    WritePrompt($"Please enter a valid number value, last value {possibleInt}");
                }
                else { valid = true; }
            }
            return response;
        }

        public int GetResponse(string[] answers)
        {
            var resp = GetStringResponse(answers);
            return answers.ToList().IndexOf(resp);
        }

        /// <summary>
        /// Performs an action from a list of possible options
        /// </summary>
        /// <param name="options"></param>
        /// <returns>the action to execute</returns>
        public void GetResponseAndDoAction(Dictionary<string, Action> options)
        {
            var answers = options.Select(o => o.Key).ToArray();
            var resp = GetStringResponse(answers);
            options[resp].Invoke();
        }

        /// <summary>
        /// Perfroms an function and returns a value from a list of possible options
        /// </summary>
        /// <param name="options">functions that return specific type</param>
        /// <returns>the action to execute</returns>
        public T GetResponseAndReturnValueFromFunc<T>(Dictionary<string, Func<T>> options)
        {
            var answers = options.Select(o => o.Key).ToArray();
            var resp = GetStringResponse(answers);
            return options[resp].Invoke();
        }

        #region PROGRESS BAR     
        /// <summary>
        /// An ASCII progress bar (https://www.codeproject.com/Tips/5255878/A-Console-Progress-Bar-in-Csharp)
        /// </summary>
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        const string _twirl = "-\\|/";

        public void WriteProgressBar(int percent, bool update = false)
        {
            if (update) { Console.Write(_back); }
            Console.Write("[");
            Console.ForegroundColor = ProgressBarColor;
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.ResetColor();
            Console.Write("] {0,3:##0}%", percent);
        }

        public void WriteProgress(int progress, bool update = false)
        {
            if (update) { Console.Write("\b"); }
            Console.ForegroundColor = ProgressBarColor;
            Console.Write(_twirl[progress % _twirl.Length]);
            Console.ResetColor();
        }
        #endregion

        public string GetStringInput(string prompt)
        {
            Console.ForegroundColor = PromptColor;
            Console.WriteLine(prompt);
            Console.WriteLine("");
            var resp = Console.ReadLine();
            Console.ResetColor();
            return resp;
        }

        public string GetOpenFilePath(string fileName = "", string fileExtension = "")
        {
            WritePrompt("Which file do you want?");
            Thread.Sleep(1000);
            OpenFileDialog fd = new OpenFileDialog();
            fd.FileName = fileName;
            if (!string.IsNullOrEmpty(fileExtension))
            {
                fd.Filter = $".{fileExtension}|{fileExtension}";
            }
            if (fd.ShowDialog() == true)
            {
                return fd.FileName;
            }
            return null;
        }

        public string GetSaveFilePath(string fileName = "")
        {
            Console.WriteLine("Where do you want to save?");
            Thread.Sleep(1000);
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = fileName;
            if (fd.ShowDialog() == true)
            {
                return fd.FileName;
            }
            return null;
        }

        public void WritePrompt(string prompt)
        {
            Console.ForegroundColor = PromptColor;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        public void WriteError(string prompt)
        {
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        public void Write(string line)
        {
            Console.WriteLine(line);
        }

        /// <summary>
        /// Gets an integer input value
        /// </summary>
        public int GetIntInput(string prompt)
        {
            int response = 0;
            if (!string.IsNullOrEmpty(prompt))
                WritePrompt(prompt);
            var valid = false;
            while (!valid)
            {
                var possibleInt = Console.ReadLine();

                if (!int.TryParse(possibleInt, out response))
                {
                    WritePrompt($"Please enter a valid integer value, last value {possibleInt}");
                }
                else { valid = true; }
            }
            return response;
        }

        /// <summary>
        /// Gets an integer input value
        /// </summary>
        public int[] GetMultipleIntInput(string prompt)
        {
            int[] response = new int[0];
            if (!string.IsNullOrEmpty(prompt))
                WritePrompt(prompt);
            var valid = false;
            while (!valid)
            {
                var possibleInt = Console.ReadLine();
                try
                {
                    response = possibleInt.Split(',')
                         .Select(x => x.Split('-'))
                         .Select(p => new { First = int.Parse(p.First()), Last = int.Parse(p.Last()) })
                         .SelectMany(x => Enumerable.Range(x.First, x.Last - x.First + 1))
                         .OrderBy(z => z).ToArray();
                    valid = true;
                }
                catch (Exception)
                {
                    WritePrompt($"Please enter a valid integer value, last value {possibleInt}");
                }
            }
            return response;
        }

        public void WriteSectionHeader(string section, ConsoleColor color = ConsoleColor.Cyan)
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write($"================{section}====================");
            Console.WriteLine("");
            Console.ForegroundColor = lastColor;
        }

        public void SkipLines(int numOfLinesToSkip)
        {
            for (int i = 0; i < numOfLinesToSkip; i++)
            {
                Console.WriteLine(string.Empty);
            }
        }
    }
}
