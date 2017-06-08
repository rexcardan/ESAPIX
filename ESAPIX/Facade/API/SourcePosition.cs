#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class SourcePosition : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public SourcePosition()
        {
            _client = new ExpandoObject();
        }

        public SourcePosition(dynamic client)
        {
            _client = client;
        }

        public double DwellTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DwellTime"))
                        return _client.DwellTime;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DwellTime; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DwellTime = value;
            }
        }

        public RadioactiveSource RadioactiveSource
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("RadioactiveSource"))
                        return _client.RadioactiveSource;
                    else
                        return default(RadioactiveSource);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            return new RadioactiveSource(_client.RadioactiveSource);
                        }
                    );
                return default(RadioactiveSource);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.RadioactiveSource = value;
            }
        }

        public double[,] Transform
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Transform"))
                        return _client.Transform;
                    else
                        return default(double[,]);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Transform; }
                    );
                return default(double[,]);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Transform = value;
            }
        }

        public VVector Translation
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Translation"))
                        return _client.Translation;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Translation; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Translation = value;
                }
            }
        }
    }
}