using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanningItem : ESAPIX.Facade.API.ApiDataObject
    {
        public PlanningItem() { _client = new ExpandoObject(); }
        public PlanningItem(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
            }
        }
        public ESAPIX.Facade.API.PlanningItemDose Dose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Dose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.PlanningItemDose>((sc) => { return new ESAPIX.Facade.API.PlanningItemDose(local._client.Dose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Dose = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValuePresentation DoseValuePresentation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DoseValuePresentation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValuePresentation>((sc) => { return (ESAPIX.Facade.Types.DoseValuePresentation)local._client.DoseValuePresentation; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DoseValuePresentation = value; }
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
        public ESAPIX.Facade.API.DVHData GetDVHCumulativeData(ESAPIX.Facade.API.Structure structure, ESAPIX.Facade.Types.DoseValuePresentation dosePresentation, ESAPIX.Facade.Types.VolumePresentation volumePresentation, System.Double binWidth)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.DVHData(local._client.GetDVHCumulativeData(structure._client, (ESAPIX.Facade.Types.DoseValuePresentation)dosePresentation, (ESAPIX.Facade.Types.VolumePresentation)volumePresentation, binWidth)); });
            return retVal;

        }
    }
}