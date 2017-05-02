#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class RadioactiveSourceModel : ApiDataObject
    {
        public RadioactiveSourceModel()
        {
            _client = new ExpandoObject();
        }

        public RadioactiveSourceModel(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public VVector ActiveSize
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ActiveSize") ? _client.ActiveSize : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.ActiveSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ActiveSize = value;
            }
        }

        public double ActivityConversionFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ActivityConversionFactor")
                        ? _client.ActivityConversionFactor
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.ActivityConversionFactor;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ActivityConversionFactor = value;
            }
        }

        public string CalculationModel
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CalculationModel")
                        ? _client.CalculationModel
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.CalculationModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CalculationModel = value;
            }
        }

        public double DoseRateConstant
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseRateConstant")
                        ? _client.DoseRateConstant
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.DoseRateConstant; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseRateConstant = value;
            }
        }

        public double HalfLife
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("HalfLife") ? _client.HalfLife : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.HalfLife; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HalfLife = value;
            }
        }

        public string LiteratureReference
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("LiteratureReference")
                        ? _client.LiteratureReference
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.LiteratureReference; });
            }
            set
            {
                if (_client is ExpandoObject) _client.LiteratureReference = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Manufacturer")
                        ? _client.Manufacturer
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Manufacturer; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Manufacturer = value;
            }
        }

        public string SourceType
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SourceType") ? _client.SourceType : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SourceType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SourceType = value;
            }
        }

        public string Status
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Status") ? _client.Status : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Status; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Status = value;
            }
        }

        public DateTime? StatusDate
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StatusDate")
                        ? _client.StatusDate
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.StatusDate; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StatusDate = value;
            }
        }

        public string StatusUserName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StatusUserName")
                        ? _client.StatusUserName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.StatusUserName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StatusUserName = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}