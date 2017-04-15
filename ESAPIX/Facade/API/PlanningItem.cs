using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PlanningItem : ESAPIX.Facade.API.ApiDataObject
    {
        public PlanningItem() { }
        public PlanningItem(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public ESAPIX.Facade.API.PlanningItemDose Dose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.PlanningItemDose(local._client.Dose);
            }
        }
        public ESAPIX.Facade.Types.DoseValuePresentation DoseValuePresentation
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.DoseValuePresentation)local._client.DoseValuePresentation;
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