#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Compensator : ApiDataObject
    {
        public Compensator()
        {
            _client = new ExpandoObject();
        }

        public Compensator(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public AddOnMaterial Material
        {
            get
            {
                if (_client is ExpandoObject) return _client.Material;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Material)) return default(AddOnMaterial);
                    return new AddOnMaterial(local._client.Material);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Material = value;
            }
        }

        public Slot Slot
        {
            get
            {
                if (_client is ExpandoObject) return _client.Slot;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Slot)) return default(Slot);
                    return new Slot(local._client.Slot);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Slot = value;
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

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}