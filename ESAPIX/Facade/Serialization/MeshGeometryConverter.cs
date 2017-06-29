#region

using System;
using System.Windows.Media.Media3D;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class MeshGeometryConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MeshGeometry3D);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var meshGeometry = new MeshGeometry3D();
            var job = JObject.Load(reader);
            var indices =
                JsonConvert.DeserializeObject<int[]>(job.GetValue(nameof(MeshGeometry3D.TriangleIndices)).ToString());
            var positions =
                JsonConvert.DeserializeObject<Point3D[]>(job.GetValue(nameof(MeshGeometry3D.Positions)).ToString());
            var normals =
                JsonConvert.DeserializeObject<Vector3D[]>(job.GetValue(nameof(MeshGeometry3D.Normals)).ToString());
            meshGeometry.Positions = new Point3DCollection(positions);
            meshGeometry.Normals = new Vector3DCollection(normals);
            meshGeometry.TriangleIndices = new System.Windows.Media.Int32Collection(indices);
            return meshGeometry;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}