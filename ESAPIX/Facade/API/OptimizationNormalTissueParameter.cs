using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationNormalTissueParameter : ESAPIX.Facade.API.OptimizationParameter
    {
        public OptimizationNormalTissueParameter() { }
        public OptimizationNormalTissueParameter(dynamic client) { _client = client; }
        public System.Double DistanceFromTargetBorderInMM
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DistanceFromTargetBorderInMM; });
            }
        }
        public System.Double EndDosePercentage
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.EndDosePercentage; });
            }
        }
        public System.Double FallOff
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.FallOff; });
            }
        }
        public System.Boolean IsAutomatic
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsAutomatic; });
            }
        }
        public System.Double Priority
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Priority; });
            }
        }
        public System.Double StartDosePercentage
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StartDosePercentage; });
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