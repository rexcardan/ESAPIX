using System;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class Tray : ApiDataObject, ITray
    {
        public DateTime? CreationDateTime { get; set; }
    }
}