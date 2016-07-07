using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;
using ESAPIX.Types;


namespace ESAPIX.Proxies
{
    public class Dose : ApiDataObject, IDose
    {
        public IEnumerable<IIsodose> Isodoses
        {
            get
            {
                return WrapEnumerable<Isodose>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public DoseValue DoseMax3D { get; set; }

        public VVector DoseMax3DLocation { get; set; }

        public int XSize { get; set; }

        public int YSize { get; set; }

        public int ZSize { get; set; }

        public double XRes { get; set; }

        public double YRes { get; set; }

        public double ZRes { get; set; }

        public VVector Origin { get; set; }

        public VVector XDirection { get; set; }

        public VVector YDirection { get; set; }

        public VVector ZDirection { get; set; }
    }
}