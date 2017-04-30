using System;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Fractionation : ApiDataObject
    {
        public Fractionation()
        {
            _client = new ExpandoObject();
        }

        public Fractionation(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) return _client.CreationDateTime;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public DoseValue DosePerFractionInPrimaryRefPoint
        {
            get
            {
                if (_client is ExpandoObject) return _client.DosePerFractionInPrimaryRefPoint;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DosePerFractionInPrimaryRefPoint))
                        return default(DoseValue);
                    return new DoseValue(local._client.DosePerFractionInPrimaryRefPoint);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DosePerFractionInPrimaryRefPoint = value;
            }
        }

        public int? NumberOfFractions
        {
            get
            {
                if (_client is ExpandoObject) return _client.NumberOfFractions;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int?>(sc => { return local._client.NumberOfFractions; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfFractions = value;
            }
        }

        public DoseValue PrescribedDosePerFraction
        {
            get
            {
                if (_client is ExpandoObject) return _client.PrescribedDosePerFraction;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.PrescribedDosePerFraction)) return default(DoseValue);
                    return new DoseValue(local._client.PrescribedDosePerFraction);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PrescribedDosePerFraction = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void SetPrescription(int numberOfFractions, DoseValue prescribedDosePerFraction,
            double prescribedPercentage)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetPrescription(numberOfFractions, prescribedDosePerFraction._client,
                    prescribedPercentage);
            });
        }
    }
}