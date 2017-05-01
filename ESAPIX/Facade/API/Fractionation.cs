#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CreationDateTime")
                        ? _client.CreationDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public Types.DoseValue DosePerFractionInPrimaryRefPoint
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DosePerFractionInPrimaryRefPoint")
                        ? _client.DosePerFractionInPrimaryRefPoint
                        : default(Types.DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DosePerFractionInPrimaryRefPoint))
                        return default(Types.DoseValue);
                    return new Types.DoseValue(local._client.DosePerFractionInPrimaryRefPoint);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NumberOfFractions")
                        ? _client.NumberOfFractions
                        : default(int?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int?>(sc => { return local._client.NumberOfFractions; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfFractions = value;
            }
        }

        public Types.DoseValue PrescribedDosePerFraction
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PrescribedDosePerFraction")
                        ? _client.PrescribedDosePerFraction
                        : default(Types.DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.PrescribedDosePerFraction))
                        return default(Types.DoseValue);
                    return new Types.DoseValue(local._client.PrescribedDosePerFraction);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PrescribedDosePerFraction = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void SetPrescription(int numberOfFractions, Types.DoseValue prescribedDosePerFraction,
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