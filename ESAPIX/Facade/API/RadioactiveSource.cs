#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class RadioactiveSource : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public RadioactiveSource()
        {
            _client = new ExpandoObject();
        }

        public RadioactiveSource(dynamic client)
        {
            _client = client;
        }

        public DateTime? CalibrationDate
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CalibrationDate"))
                        return _client.CalibrationDate;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CalibrationDate; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CalibrationDate = value;
            }
        }

        public bool NominalActivity
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NominalActivity"))
                        return _client.NominalActivity;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NominalActivity; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NominalActivity = value;
            }
        }

        public RadioactiveSourceModel RadioactiveSourceModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("RadioactiveSourceModel"))
                        return _client.RadioactiveSourceModel;
                    else
                        return default(RadioactiveSourceModel);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.RadioactiveSourceModel != null)
                                return new RadioactiveSourceModel(_client.RadioactiveSourceModel);
                            return null;
                        }
                    );
                return default(RadioactiveSourceModel);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.RadioactiveSourceModel = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SerialNumber"))
                        return _client.SerialNumber;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SerialNumber; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SerialNumber = value;
            }
        }

        public double Strength
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Strength"))
                        return _client.Strength;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Strength; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Strength = value;
                }
            }
        }
    }
}