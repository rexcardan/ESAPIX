using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class Isodose : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.DoseValue Level
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Level"))
                    {
                        return _client.Level;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Level;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DoseValue);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Level = (value);
                }
                else
                {
                }
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Color"))
                    {
                        return _client.Color;
                    }
                    else
                    {
                        return default (System.Windows.Media.Color);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Color;
                    }

                    );
                }
                else
                {
                    return default (System.Windows.Media.Color);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Color = (value);
                }
                else
                {
                }
            }
        }

        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MeshGeometry"))
                    {
                        return _client.MeshGeometry;
                    }
                    else
                    {
                        return default (System.Windows.Media.Media3D.MeshGeometry3D);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    MeshGeometry3D mesh = (new MeshGeometry3D());
                    var points = (new Point3D[]{});
                    var normals = (new Vector3D[]{});
                    var indices = (new Int32[]{});
                    XC.Instance.Invoke(() =>
                    {
                        if ((_client.MeshGeometry) != (null))
                        {
                            points = (new Point3D[_client.MeshGeometry.Positions.Count]);
                            normals = (new Vector3D[_client.MeshGeometry.Normals.Count]);
                            indices = (new Int32[_client.MeshGeometry.TriangleIndices.Count]);
                            _client.MeshGeometry.Positions.CopyTo(points, 0);
                            _client.MeshGeometry.Normals.CopyTo(normals, 0);
                            _client.MeshGeometry.TriangleIndices.CopyTo(indices, 0);
                        }
                    }

                    );
                    if ((points.Length) == (0))
                    {
                        return null;
                    }

                    mesh.Positions = (new Point3DCollection(points));
                    mesh.Normals = (new Vector3DCollection(normals));
                    mesh.TriangleIndices = (new Int32Collection(indices));
                    return mesh;
                }
                else
                {
                    return default (System.Windows.Media.Media3D.MeshGeometry3D);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.MeshGeometry = (value);
                }
                else
                {
                }
            }
        }

        public Isodose()
        {
            _client = (new ExpandoObject());
        }

        public Isodose(dynamic client)
        {
            _client = (client);
        }
    }
}