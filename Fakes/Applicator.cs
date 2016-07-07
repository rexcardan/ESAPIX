using System;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class Applicator : ApiDataObject, IApplicator
    {
        public DateTime? CreationDateTime { get; set; }
    }
}