#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Block : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Block()
        {
            _client = new ExpandoObject();
        }

        public Block(dynamic client)
        {
            _client = client;
        }

        public AddOnMaterial AddOnMaterial
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("AddOnMaterial"))
                        return _client.AddOnMaterial;
                    else
                        return default(AddOnMaterial);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(
                        sc => { return new AddOnMaterial(_client.AddOnMaterial); }
                    );
                return default(AddOnMaterial);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.AddOnMaterial = value;
            }
        }

        public bool IsDiverging
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsDiverging"))
                        return _client.IsDiverging;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsDiverging; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsDiverging = value;
            }
        }

        public double TransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TransmissionFactor"))
                        return _client.TransmissionFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TransmissionFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TransmissionFactor = value;
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
                    _client.Tray = value;
            }
        }

        public double TrayTransmissionFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TrayTransmissionFactor"))
                        return _client.TrayTransmissionFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TrayTransmissionFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TrayTransmissionFactor = value;
            }
        }

        public BlockType Type
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Type"))
                        return _client.Type;
                    else
                        return default(BlockType);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Type; }
                    );
                return default(BlockType);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Type = value;
                }
            }
        }
    }
}