#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;
using System.Windows.Media.Media3D;

#endregion

namespace ESAPIX.Facade.API
{
    public class Isodose : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public Isodose()
        {
            _client = new ExpandoObject();
        }

        public Isodose(dynamic client)
        {
            _client = client;
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Color"))
                        return _client.Color;
                    else
                        return default(System.Windows.Media.Color);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Color; }
                    );
                return default(System.Windows.Media.Color);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Color = value;
            }
        }

        public DoseValue Level
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Level"))
                        return _client.Level;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Level; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Level = value;
            }
        }

        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MeshGeometry")
                        ? _client.MeshGeometry
                        : default(System.Windows.Media.Media3D.MeshGeometry3D);

                MeshGeometry3D mesh = new MeshGeometry3D();
                Point3D[] points = new Point3D[0];
                Vector3D[] normals = new Vector3D[0];
                int[] indices = new int[0];

                XC.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    points = new Point3D[_client.MeshGeometry.Positions.Count];
                    normals = new Vector3D[_client.MeshGeometry.Normals.Count];
                    indices = new int[_client.MeshGeometry.TriangleIndices.Count];
                    _client.MeshGeometry.Positions.CopyTo(points, 0);
                    _client.MeshGeometry.Normals.CopyTo(normals, 0);
                    _client.MeshGeometry.TriangleIndices.CopyTo(indices, 0);
                });
                mesh.Positions = new Point3DCollection(points);
                return mesh;
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.MeshGeometry = value;
                }
            }
        }
    }
}