using System;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class ApiDataObject :  IApiDataObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string HistoryUserName { get; set; }

        public DateTime HistoryDateTime { get; set; }
    }
}