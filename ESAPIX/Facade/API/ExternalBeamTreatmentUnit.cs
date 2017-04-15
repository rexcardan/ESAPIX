using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ExternalBeamTreatmentUnit : ESAPIX.Facade.API.ApiDataObject
    {
        public ExternalBeamTreatmentUnit() { }
        public ExternalBeamTreatmentUnit(dynamic client) { _client = client; }
        public System.String MachineModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineModel; });
            }
        }
        public System.String MachineModelName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineModelName; });
            }
        }
        public System.String MachineScaleDisplayName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineScaleDisplayName; });
            }
        }
        public System.Double SourceAxisDistance
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SourceAxisDistance; });
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