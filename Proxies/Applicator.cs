using System;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class Applicator : ApiDataObject, IApplicator
    {
        public DateTime? CreationDateTime { get; set; }
    }
}