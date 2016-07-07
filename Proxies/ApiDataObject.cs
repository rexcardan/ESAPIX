using System;
using ESAPIX.Interfaces;

namespace ESAPIX.Proxies
{
    public class ApiDataObject : VMSProxy, IApiDataObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string HistoryUserName { get; set; }

        public DateTime HistoryDateTime { get; set; }
    }
}