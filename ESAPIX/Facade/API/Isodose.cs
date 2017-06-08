#region

using System.Dynamic;
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
                    if (((ExpandoObject) _client).HasProperty("MeshGeometry"))
                        return _client.MeshGeometry;
                    else
                        return default(System.Windows.Media.Media3D.MeshGeometry3D);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MeshGeometry; }
                    );
                return default(System.Windows.Media.Media3D.MeshGeometry3D);
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