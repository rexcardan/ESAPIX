using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.IO
{
    public class CsvFile
    {
        public List<dynamic[]> Rows { get; set; } = new List<dynamic[]>();

        public static CsvFile Read(string filePath)
        {
            var csv = new CsvFile();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var row = line.Split(',')
                    .Select(data => data.Trim())
                    .ToArray();

                csv.Rows.Add(row);
            }
            return csv;
        }

        public List<T> Column<T>(string columnName)
        {
            if(typeof(T) == typeof(string))
            {
                return Column(columnName)
                    .Select(s => (T)s).ToList();
            }
            else if(typeof(T) == typeof(double))
            {
                return Column(columnName)
                     .Select(d =>
                     {
                         double num;
                         var isNum = double.TryParse(d,
                             NumberStyles.AllowDecimalPoint,
                             CultureInfo.InvariantCulture, out num);
                         return isNum ? num : default(double);
                     })
                     .Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(int))
            {
                return Column(columnName)
                     .Select(d =>
                     {
                         int num;
                         var isNum = int.TryParse(d,
                             NumberStyles.AllowDecimalPoint,
                             CultureInfo.InvariantCulture, out num);
                         return isNum ? num : default(int);
                     })
                     .Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(float))
            {
                return Column(columnName)
                     .Select(d =>
                     {
                         float num;
                         var isNum = float.TryParse(d,
                             NumberStyles.AllowDecimalPoint,
                             CultureInfo.InvariantCulture, out num);
                         return isNum ? num : default(float);
                     })
                     .Cast<T>().ToList();
            }
            throw new ArgumentException("Only types string, int, double, and float are supported");
        }

        public void AddRow(params dynamic[] rowItems)
        {
            Rows.Add(rowItems);
        }

        public List<dynamic> Column(string columnName)
        {
            if (!Rows.Any()) { return new List<dynamic>(); }
            var index = Rows.First().ToList().IndexOf(columnName);
            if (index == -1) { return new List<dynamic>(); } //no match
            else
            {
                List<dynamic> data = new List<dynamic>();
                foreach(var row in Rows.Skip(1)) //Skip header
                {
                    if (row.Length >= index + 1)
                    {
                        data.Add(row[index]);
                    }
                    else { data.Add(string.Empty); }
                }
                return data;
            }
        }

        public void Write(string filePath)
        {
            List<string> lines = new List<string>();

            foreach (var row in Rows)
            {
                var line = string.Join(",", row.Select(r => r.ToString()).ToArray());
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines.ToArray());
        }
    }
}
