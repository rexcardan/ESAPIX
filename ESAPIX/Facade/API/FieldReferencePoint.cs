using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class FieldReferencePoint : ESAPIX.Facade.API.ApiDataObject
    {
        public FieldReferencePoint() { }
        public FieldReferencePoint(dynamic client) { _client = client; }
        public System.Double EffectiveDepth
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.EffectiveDepth; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue FieldDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.FieldDose);
            }
        }
        public System.Boolean IsFieldDoseNominal
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsFieldDoseNominal; });
            }
        }
        public System.Boolean IsPrimaryReferencePoint
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsPrimaryReferencePoint; });
            }
        }
        public ESAPIX.Facade.API.ReferencePoint ReferencePoint
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ReferencePoint(local._client.ReferencePoint);
            }
        }
        public ESAPIX.Facade.Types.VVector RefPointLocation
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.RefPointLocation);
            }
        }
        public System.Double SSD
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SSD; });
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