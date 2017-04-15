using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class EstimatedDVH : ESAPIX.Facade.API.ApiDataObject
    {
        public EstimatedDVH() { }
        public EstimatedDVH(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.DVHPoint[] CurveData
        {
            get
            {
                var local = this;
                return ArrayHelper.GenerateDVHPointArray(local._client.CurveData);
            }
        }
        public ESAPIX.Facade.API.PlanSetup PlanSetup
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.PlanSetup(local._client.PlanSetup);
            }
        }
        public System.String PlanSetupId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanSetupId; });
            }
        }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Structure(local._client.Structure);
            }
        }
        public System.String StructureId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.StructureId; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue TargetDoseLevel
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.TargetDoseLevel);
            }
        }
        public ESAPIX.Facade.Types.DVHEstimateType Type
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.DVHEstimateType)local._client.Type;
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