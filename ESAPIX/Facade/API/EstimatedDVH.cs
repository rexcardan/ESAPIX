using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class EstimatedDVH : ESAPIX.Facade.API.ApiDataObject
    {
        public EstimatedDVH() { _client = new ExpandoObject(); }
        public EstimatedDVH(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CurveData; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DVHPoint[]>((sc) => { return ArrayHelper.GenerateDVHPointArray(local._client.CurveData); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CurveData = value; }
            }
        }
        public ESAPIX.Facade.API.PlanSetup PlanSetup
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanSetup; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.PlanSetup>((sc) => { return new ESAPIX.Facade.API.PlanSetup(local._client.PlanSetup); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanSetup = value; }
            }
        }
        public System.String PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanSetupId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PlanSetupId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanSetupId = value; }
            }
        }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Structure; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Structure>((sc) => { return new ESAPIX.Facade.API.Structure(local._client.Structure); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Structure = value; }
            }
        }
        public System.String StructureId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StructureId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.StructureId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StructureId = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue TargetDoseLevel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TargetDoseLevel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.TargetDoseLevel); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TargetDoseLevel = value; }
            }
        }
        public ESAPIX.Facade.Types.DVHEstimateType Type
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Type; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DVHEstimateType>((sc) => { return (ESAPIX.Facade.Types.DVHEstimateType)local._client.Type; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Type = value; }
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