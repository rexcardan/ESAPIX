using System.Dynamic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

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

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public Color Color
        {
            get
            {
                if (_client is ExpandoObject) return _client.Color;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Color>(sc => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public DoseValue Level
        {
            get
            {
                if (_client is ExpandoObject) return _client.Level;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Level)) return default(DoseValue);
                    return new DoseValue(local._client.Level);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Level = value;
            }
        }

        public MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject) return _client.MeshGeometry;
                var local = this;
                return X.Instance.CurrentContext.GetValue<MeshGeometry3D>(sc => { return local._client.MeshGeometry; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MeshGeometry = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}