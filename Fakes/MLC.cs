using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class MLC :  IMLC
    {
        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public double MinDoseDynamicLeafGap { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string HistoryUserName { get; set; }

        public DateTime HistoryDateTime { get; set; }
    }
}
