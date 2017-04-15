using System;
using System.Collections.Generic;
using System.Collections;
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
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PlanSumComponents;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.PlanSumComponent();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
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
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PlanSetups;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.PlanSetup();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
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