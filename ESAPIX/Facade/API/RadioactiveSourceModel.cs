#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class RadioactiveSourceModel : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public RadioactiveSourceModel()
        {
            _client = new ExpandoObject();
        }

        public RadioactiveSourceModel(dynamic client)
        {
            _client = client;
        }

        public VVector ActiveSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ActiveSize"))
                        return _client.ActiveSize;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ActiveSize; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ActiveSize = value;
            }
        }

        public double ActivityConversionFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ActivityConversionFactor"))
                        return _client.ActivityConversionFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ActivityConversionFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ActivityConversionFactor = value;
            }
        }

        public string CalculationModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CalculationModel"))
                        return _client.CalculationModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CalculationModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CalculationModel = value;
            }
        }

        public double DoseRateConstant
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DoseRateConstant"))
                        return _client.DoseRateConstant;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DoseRateConstant; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DoseRateConstant = value;
            }
        }

        public double HalfLife
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("HalfLife"))
                        return _client.HalfLife;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.HalfLife; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.HalfLife = value;
            }
        }

        public string LiteratureReference
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("LiteratureReference"))
                        return _client.LiteratureReference;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.LiteratureReference; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.LiteratureReference = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Manufacturer"))
                        return _client.Manufacturer;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Manufacturer; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Manufacturer = value;
            }
        }

        public string SourceType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SourceType"))
                        return _client.SourceType;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SourceType; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SourceType = value;
            }
        }

        public string Status
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Status"))
                        return _client.Status;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Status; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Status = value;
            }
        }

        public DateTime? StatusDate
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StatusDate"))
                        return _client.StatusDate;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StatusDate; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StatusDate = value;
            }
        }

        public string StatusUserName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StatusUserName"))
                        return _client.StatusUserName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StatusUserName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.StatusUserName = value;
                }
            }
        }
    }
}