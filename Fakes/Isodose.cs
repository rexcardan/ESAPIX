using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPIX.Interfaces;
using ESAPIX.Types;

namespace ESAPIX.Fakes
{
    public class Isodose : IIsodose
    {
        public DoseValue Level { get; set; }

        public Color Color { get; set; }

        public MeshGeometry3D MeshGeometry { get; set; }
    }
}