using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Block : ApiDataObject
    {
        public Block()
        {
            _client = new ExpandoObject();
        }

        public Block(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public AddOnMaterial AddOnMaterial
        {
            get
            {
                if (_client is ExpandoObject) return _client.AddOnMaterial;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.AddOnMaterial)) return default(AddOnMaterial);
                    return new AddOnMaterial(local._client.AddOnMaterial);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.AddOnMaterial = value;
            }
        }

        public bool IsDiverging
        {
            get
            {
                if (_client is ExpandoObject) return _client.IsDiverging;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsDiverging; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsDiverging = value;
            }
        }

        public double TransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject) return _client.TransmissionFactor;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.TransmissionFactor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TransmissionFactor = value;
            }
        }

        public Tray Tray
        {
            get
            {
                if (_client is ExpandoObject) return _client.Tray;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Tray)) return default(Tray);
                    return new Tray(local._client.Tray);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Tray = value;
            }
        }

        public double TrayTransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject) return _client.TrayTransmissionFactor;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(
                    sc => { return local._client.TrayTransmissionFactor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TrayTransmissionFactor = value;
            }
        }

        public BlockType Type
        {
            get
            {
                if (_client is ExpandoObject) return _client.Type;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (BlockType) local._client.Type; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Type = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}