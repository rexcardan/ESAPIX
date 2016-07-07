using System;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class Wedge : ApiDataObject, IWedge
    {
        public double WedgeAngle { get; set; }

        public double Direction { get; set; }

        public DateTime? CreationDateTime { get; set; }
    }
}