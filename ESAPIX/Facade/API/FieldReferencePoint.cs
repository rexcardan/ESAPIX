using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

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

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double EffectiveDepth
        {
            get
            {
                if (_client is ExpandoObject) return _client.EffectiveDepth;
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
                if (_client is ExpandoObject) return _client.FieldDose;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.FieldDose)) return default(DoseValue);
                    return new DoseValue(local._client.FieldDose);
                });
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
                if (_client is ExpandoObject) return _client.IsFieldDoseNominal;
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
                if (_client is ExpandoObject) return _client.IsPrimaryReferencePoint;
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
                if (_client is ExpandoObject) return _client.ReferencePoint;
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
                if (_client is ExpandoObject) return _client.RefPointLocation;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.RefPointLocation)) return default(VVector);
                    return new VVector(local._client.RefPointLocation);
                });
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
                if (_client is ExpandoObject) return _client.SSD;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SSD; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SSD = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}