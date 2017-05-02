#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class FieldReferencePoint : ApiDataObject
    {
        public FieldReferencePoint()
        {
            _client = new ExpandoObject();
        }

        public FieldReferencePoint(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double EffectiveDepth
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("EffectiveDepth")
                        ? _client.EffectiveDepth
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.EffectiveDepth; });
            }
            set
            {
                if (_client is ExpandoObject) _client.EffectiveDepth = value;
            }
        }

        public DoseValue FieldDose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("FieldDose") ? _client.FieldDose : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.FieldDose; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FieldDose = value;
            }
        }

        public bool IsFieldDoseNominal
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsFieldDoseNominal")
                        ? _client.IsFieldDoseNominal
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsFieldDoseNominal; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsFieldDoseNominal = value;
            }
        }

        public bool IsPrimaryReferencePoint
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsPrimaryReferencePoint")
                        ? _client.IsPrimaryReferencePoint
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc =>
                {
                    return local._client.IsPrimaryReferencePoint;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsPrimaryReferencePoint = value;
            }
        }

        public ReferencePoint ReferencePoint
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ReferencePoint")
                        ? _client.ReferencePoint
                        : default(ReferencePoint);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ReferencePoint)) return default(ReferencePoint);
                    return new ReferencePoint(local._client.ReferencePoint);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ReferencePoint = value;
            }
        }

        public VVector RefPointLocation
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("RefPointLocation")
                        ? _client.RefPointLocation
                        : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.RefPointLocation; });
            }
            set
            {
                if (_client is ExpandoObject) _client.RefPointLocation = value;
            }
        }

        public double SSD
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SSD") ? _client.SSD : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SSD; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SSD = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}