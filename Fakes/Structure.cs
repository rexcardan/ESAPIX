using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPIX.Interfaces;
using ESAPIX.Types;
using Newtonsoft.Json;

namespace ESAPIX.Fakes
{
    public class Structure : ApiDataObject, IStructure
    {
        public bool IsEmpty { get; set; }

        public bool HasSegment { get; set; }

        public Color Color { get; set; }

        public string DicomType { get; set; }

        public VVector CenterPoint { get; set; }

        public double Volume { get; set; }

        //TODO Include
        [JsonIgnore]
        public MeshGeometry3D MeshGeometry { get; set; }

        public VVector[][] GetContoursOnImagePlane(int z)
        {
           throw new NotImplementedException();
        }

        public bool GetAssignedHU(out double huValue)
        {
            throw new NotImplementedException();
        }

        public bool IsPointInsideSegment(VVector point)
        {
            throw new NotImplementedException();
        }
    }
}