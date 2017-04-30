using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class EstimatedDVH : ApiDataObject
    {
        public EstimatedDVH()
        {
            _client = new ExpandoObject();
        }

        public EstimatedDVH(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject) return _client.CurveData;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DVHPoint[]>(sc =>
                {
                    return ArrayHelper.GenerateDVHPointArray(local._client.CurveData);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CurveData = value;
            }
        }

        public PlanSetup PlanSetup
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanSetup;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.PlanSetup)) return default(PlanSetup);
                    return new PlanSetup(local._client.PlanSetup);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanSetup = value;
            }
        }

        public string PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject) return _client.PlanSetupId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PlanSetupId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanSetupId = value;
            }
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) return _client.Structure;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Structure)) return default(Structure);
                    return new Structure(local._client.Structure);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Structure = value;
            }
        }

        public string StructureId
        {
            get
            {
                if (_client is ExpandoObject) return _client.StructureId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.StructureId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StructureId = value;
            }
        }

        public DoseValue TargetDoseLevel
        {
            get
            {
                if (_client is ExpandoObject) return _client.TargetDoseLevel;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.TargetDoseLevel)) return default(DoseValue);
                    return new DoseValue(local._client.TargetDoseLevel);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TargetDoseLevel = value;
            }
        }

        public DVHEstimateType Type
        {
            get
            {
                if (_client is ExpandoObject) return _client.Type;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (DVHEstimateType) local._client.Type; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Type = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}