#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationIMRTBeamParameter : OptimizationParameter, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationIMRTBeamParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationIMRTBeamParameter(dynamic client)
        {
            _client = client;
        }

        public Beam Beam
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Beam"))
                        return _client.Beam;
                    else
                        return default(Beam);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Beam(_client.Beam); }
                    );
                return default(Beam);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Beam = value;
            }
        }

        public string BeamId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("BeamId"))
                        return _client.BeamId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.BeamId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.BeamId = value;
            }
        }

        public bool Excluded
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Excluded"))
                        return _client.Excluded;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Excluded; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Excluded = value;
            }
        }

        public bool FixedJaws
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("FixedJaws"))
                        return _client.FixedJaws;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.FixedJaws; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.FixedJaws = value;
            }
        }

        public double SmoothX
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SmoothX"))
                        return _client.SmoothX;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SmoothX; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SmoothX = value;
            }
        }

        public double SmoothY
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SmoothY"))
                        return _client.SmoothY;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SmoothY; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.SmoothY = value;
                }
            }
        }
    }
}