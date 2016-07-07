using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IStructure : IApiDataObject
    {
        bool IsEmpty { get; }

        bool HasSegment { get; }

        Color Color { get; }

        string DicomType { get; }

        VVector CenterPoint { get; }
        double Volume { get; }

        MeshGeometry3D MeshGeometry { get; }

        VVector[][] GetContoursOnImagePlane(int z);

        bool GetAssignedHU(out double huValue);

        bool IsPointInsideSegment(VVector point);
    }
}
