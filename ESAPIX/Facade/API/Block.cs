#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public AddOnMaterial AddOnMaterial
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("AddOnMaterial")
                        ? _client.AddOnMaterial
                        : default(AddOnMaterial);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsDiverging") ? _client.IsDiverging : default(bool);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TransmissionFactor")
                        ? _client.TransmissionFactor
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Tray") ? _client.Tray : default(Tray);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TrayTransmissionFactor")
                        ? _client.TrayTransmissionFactor
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(
                    sc => { return local._client.TrayTransmissionFactor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TrayTransmissionFactor = value;
            }
        }

        public Types.BlockType Type
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Type") ? _client.Type : default(Types.BlockType);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (Types.BlockType) local._client.Type; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Type = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}