using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanSum : ESAPIX.Facade.API.PlanningItem
    {
        public PlanSum() { _client = new ExpandoObject(); }
        public PlanSum(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Course; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Course>((sc) => { return new ESAPIX.Facade.API.Course(local._client.Course); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Course = value; }
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
                if (_client is ExpandoObject) { return _client.StructureSet; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.StructureSet>((sc) => { return new ESAPIX.Facade.API.StructureSet(local._client.StructureSet); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StructureSet = value; }
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