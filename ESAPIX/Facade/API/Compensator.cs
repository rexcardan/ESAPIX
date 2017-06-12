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
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Material != null)
                                return new AddOnMaterial(_client.Material);
                            return null;
                        }
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
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Slot != null)
                                return new Slot(_client.Slot);
                            return null;
                        }
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
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Tray != null)
                                return new Tray(_client.Tray);
                            return null;
                        }
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