using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class StructureSet : ApiDataObject, IStructureSet
    {
        public string UID { get; set; }

        public IImage Image
        {
            get
            {
                return Wrap<Image>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<IStructure> Structures
        {
            get
            {
                return WrapEnumerable<Structure>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
    }
}