using System.Collections.Generic;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class StructureSet : ApiDataObject, IStructureSet
    {
        public string UID { get; set; }

        public IImage Image { get; set; }

        public IEnumerable<IStructure> Structures
        {
            get;
            set;
        }
    }
}