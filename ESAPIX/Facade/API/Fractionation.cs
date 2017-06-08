#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Fractionation : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Fractionation()
        {
            _client = new ExpandoObject();
        }

        public Fractionation(dynamic client)
        {
            _client = client;
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationDateTime"))
                        return _client.CreationDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationDateTime = value;
            }
        }

        public DoseValue DosePerFractionInPrimaryRefPoint
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DosePerFractionInPrimaryRefPoint"))
                        return _client.DosePerFractionInPrimaryRefPoint;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(
                        sc => { return _client.DosePerFractionInPrimaryRefPoint; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DosePerFractionInPrimaryRefPoint = value;
            }
        }

        public int? NumberOfFractions
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NumberOfFractions"))
                        return _client.NumberOfFractions;
                    else
                        return default(int?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NumberOfFractions; }
                    );
                return default(int?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NumberOfFractions = value;
            }
        }

        public DoseValue PrescribedDosePerFraction
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PrescribedDosePerFraction"))
                        return _client.PrescribedDosePerFraction;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PrescribedDosePerFraction; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.PrescribedDosePerFraction = value;
                }
            }
        }

        public void SetPrescription(int numberOfFractions, DoseValue prescribedDosePerFraction,
            double prescribedPercentage)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        _client.SetPrescription(numberOfFractions, prescribedDosePerFraction, prescribedPercentage);
                    }
                );
            else
                _client.SetPrescription(numberOfFractions, prescribedDosePerFraction, prescribedPercentage);
        }
    }
}