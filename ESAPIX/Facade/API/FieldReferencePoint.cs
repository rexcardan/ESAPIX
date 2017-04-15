using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class FieldReferencePoint : ESAPIX.Facade.API.ApiDataObject
    {
        public FieldReferencePoint() { _client = new ExpandoObject(); }
        public FieldReferencePoint(dynamic client) { _client = client; }
        public System.Double EffectiveDepth
        {
            get
            {
                if (_client is ExpandoObject) { return _client.EffectiveDepth; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.EffectiveDepth; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.EffectiveDepth = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue FieldDose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FieldDose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.FieldDose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FieldDose = value; }
            }
        }
        public System.Boolean IsFieldDoseNominal
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsFieldDoseNominal; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsFieldDoseNominal; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsFieldDoseNominal = value; }
            }
        }
        public System.Boolean IsPrimaryReferencePoint
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsPrimaryReferencePoint; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsPrimaryReferencePoint; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsPrimaryReferencePoint = value; }
            }
        }
        public ESAPIX.Facade.API.ReferencePoint ReferencePoint
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ReferencePoint; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ReferencePoint>((sc) => { return new ESAPIX.Facade.API.ReferencePoint(local._client.ReferencePoint); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ReferencePoint = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector RefPointLocation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.RefPointLocation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.RefPointLocation); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.RefPointLocation = value; }
            }
        }
        public System.Double SSD
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SSD; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SSD; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SSD = value; }
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
    }
}