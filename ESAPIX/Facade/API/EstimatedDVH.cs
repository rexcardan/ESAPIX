#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Types.DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CurveData")
                        ? _client.CurveData
                        : default(Types.DVHPoint[]);
                var local = this;
                return X.Instance.CurrentContext.GetValue<Types.DVHPoint[]>(sc =>
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanSetup") ? _client.PlanSetup : default(PlanSetup);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanSetupId")
                        ? _client.PlanSetupId
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Structure") ? _client.Structure : default(Structure);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StructureId")
                        ? _client.StructureId
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.StructureId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StructureId = value;
            }
        }

        public Types.DoseValue TargetDoseLevel
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TargetDoseLevel")
                        ? _client.TargetDoseLevel
                        : default(Types.DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.TargetDoseLevel)) return default(Types.DoseValue);
                    return new Types.DoseValue(local._client.TargetDoseLevel);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TargetDoseLevel = value;
            }
        }

        public Types.DVHEstimateType Type
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Type")
                        ? _client.Type
                        : default(Types.DVHEstimateType);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (Types.DVHEstimateType) local._client.Type; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Type = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}