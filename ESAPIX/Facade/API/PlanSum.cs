using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSum : ESAPIX.Facade.API.PlanningItem
    {
        public PlanSum() { }
        public PlanSum(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Course(local._client.Course);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSumComponent> PlanSumComponents
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.PlanSumComponent>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.PlanSumComponents).Select(s => new ESAPIX.Facade.API.PlanSumComponent(s));
                });
            }
        }
        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.StructureSet(local._client.StructureSet);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlanSetups
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.PlanSetup>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.PlanSetups).Select(s => new ESAPIX.Facade.API.PlanSetup(s));
                });
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
        public ESAPIX.Facade.Types.PlanSumOperation GetPlanSumOperation(ESAPIX.Facade.API.PlanSetup planSetupInPlanSum)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return (ESAPIX.Facade.Types.PlanSumOperation)local._client.GetPlanSumOperation(planSetupInPlanSum._client); });
            return retVal;

        }
        public System.Double GetPlanWeight(ESAPIX.Facade.API.PlanSetup planSetupInPlanSum)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetPlanWeight(planSetupInPlanSum._client); });
            return retVal;

        }
    }
}