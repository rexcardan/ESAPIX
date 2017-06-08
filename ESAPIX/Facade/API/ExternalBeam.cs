#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ExternalBeam : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public ExternalBeam()
        {
            _client = new ExpandoObject();
        }

        public ExternalBeam(dynamic client)
        {
            _client = client;
        }

        public double SourceAxisDistance
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SourceAxisDistance"))
                        return _client.SourceAxisDistance;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SourceAxisDistance; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SourceAxisDistance = value;
            }
        }

        public string MachineModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MachineModel"))
                        return _client.MachineModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MachineModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MachineModel = value;
            }
        }

        public string MachineModelName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MachineModelName"))
                        return _client.MachineModelName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MachineModelName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MachineModelName = value;
            }
        }

        public string MachineScaleDisplayName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MachineScaleDisplayName"))
                        return _client.MachineScaleDisplayName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MachineScaleDisplayName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.MachineScaleDisplayName = value;
                }
            }
        }
    }
}