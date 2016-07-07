using System;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class Tray : ApiDataObject, ITray
    {
        public DateTime? CreationDateTime { get; set; }
    }
}