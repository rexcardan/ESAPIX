#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Isodose : SerializableObject
    {
        public Isodose()
        {
            _client = new ExpandoObject();
        }

        public Isodose(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Color")
                        ? _client.Color
                        : default(System.Windows.Media.Color);
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>(sc =>
                {
                    return local._client.Color;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public Types.DoseValue Level
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Level") ? _client.Level : default(Types.DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Level)) return default(Types.DoseValue);
                    return new Types.DoseValue(local._client.Level);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Level = value;
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
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Media3D.MeshGeometry3D>(sc =>
                {
                    return local._client.MeshGeometry;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MeshGeometry = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}