using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IIsodose
    {
        DoseValue Level { get; }

        Color Color { get; }

        MeshGeometry3D MeshGeometry { get; }
    }
}
