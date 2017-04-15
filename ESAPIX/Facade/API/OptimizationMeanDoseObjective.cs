using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationMeanDoseObjective : ESAPIX.Facade.API.OptimizationObjective
    {
        public OptimizationMeanDoseObjective() { }
        public OptimizationMeanDoseObjective(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.DoseValue Dose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.Dose);
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