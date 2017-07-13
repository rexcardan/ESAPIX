#region

using System.Dynamic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

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

        public Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Color"))
                        return _client.Color;
                    else
                        return default(Color);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Color; }
                    );
                return default(Color);
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

        public MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MeshGeometry"))
                        return _client.MeshGeometry;
                    else
                        return default(MeshGeometry3D);
                if (XC.Instance.CurrentContext != null)
                {
                    var mesh = new MeshGeometry3D();
                    var points = new Point3D[] { };
                    var normals = new Vector3D[] { };
                    var indices = new int[] { };
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            points = new Point3D[_client.MeshGeometry.Positions.Count];
                            normals = new Vector3D[_client.MeshGeometry.Normals.Count];
                            indices = new int[_client.MeshGeometry.TriangleIndices.Count];
                            _client.MeshGeometry.Positions.CopyTo(points, 0);
                            _client.MeshGeometry.Normals.CopyTo(normals, 0);
                            _client.MeshGeometry.TriangleIndices.CopyTo(indices, 0);
                        }
                    );
                    mesh.Positions = new Point3DCollection(points);
                    mesh.Normals = new Vector3DCollection(normals);
                    mesh.TriangleIndices = new Int32Collection(indices);
                    return mesh;
                }
                return default(MeshGeometry3D);
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