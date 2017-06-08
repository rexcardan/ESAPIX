#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Compensator : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Compensator()
        {
            _client = new ExpandoObject();
        }

        public Compensator(dynamic client)
        {
            _client = client;
        }

        public AddOnMaterial Material
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Material"))
                        return _client.Material;
                    else
                        return default(AddOnMaterial);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new AddOnMaterial(_client.Material); }
                    );
                return default(AddOnMaterial);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Material = value;
            }
        }

        public Slot Slot
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Slot"))
                        return _client.Slot;
                    else
                        return default(Slot);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Slot(_client.Slot); }
                    );
                return default(Slot);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Slot = value;
            }
        }

        public Tray Tray
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Tray"))
                        return _client.Tray;
                    else
                        return default(Tray);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Tray(_client.Tray); }
                    );
                return default(Tray);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Tray = value;
                }
            }
        }
    }
}