#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class PlanningItem : ApiDataObject
    {
        public PlanningItem()
        {
            _client = new ExpandoObject();
        }

        public PlanningItem(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CreationDateTime")
                        ? _client.CreationDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public PlanningItemDose Dose
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Dose") ? _client.Dose : default(PlanningItemDose);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Dose)) return default(PlanningItemDose);
                    return new PlanningItemDose(local._client.Dose);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Dose = value;
            }
        }

        public DoseValuePresentation DoseValuePresentation
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseValuePresentation")
                        ? _client.DoseValuePresentation
                        : default(DoseValuePresentation);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValuePresentation>(sc =>
                {
                    return local._client.DoseValuePresentation;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseValuePresentation = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public DVHData GetDVHCumulativeData(Structure structure, DoseValuePresentation dosePresentation,
            VolumePresentation volumePresentation, double binWidth)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new DVHData(local._client.GetDVHCumulativeData(structure._client, dosePresentation,
                    volumePresentation, binWidth));
            });
            return retVal;
        }
    }
}