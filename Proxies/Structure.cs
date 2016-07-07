using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPIX.Interfaces;
using ESAPIX.Types;
using Newtonsoft.Json;
using System.Reflection;
using ESAPIX.Helpers;

namespace ESAPIX.Proxies
{
    public class Structure : ApiDataObject, IStructure
    {
        public bool IsEmpty { get; set; }

        public bool HasSegment { get; set; }

        public Color Color { get; set; }

        public string DicomType { get; set; }

        public VVector CenterPoint { get; set; }

        public double Volume { get; set; }

        [JsonIgnore]
        public MeshGeometry3D MeshGeometry
        {
            get
            {
                return Wrap<MeshGeometry3D>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public VVector[][] GetContoursOnImagePlane(int z)
        {
            return InvokeAndWrap<VVector[][]>(MethodBase.GetCurrentMethod().Name, z);
        }

        public bool GetAssignedHU(out double huValue)
        {
            huValue = double.NaN;
            var args = new object[] { huValue };
            var hu = InvokeAndWrap<bool>(MethodBase.GetCurrentMethod().Name, args);
            huValue = (double)args[0];
            return hu;
        }

        public bool IsPointInsideSegment(VVector point)
        {
            var args = MapHelper.MapDefault(point);
            return InvokeAndWrap<bool>(MethodBase.GetCurrentMethod().Name, args);
        }
    }
}