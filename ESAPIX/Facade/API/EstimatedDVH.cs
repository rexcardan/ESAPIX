#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class EstimatedDVH : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public EstimatedDVH()
        {
            _client = new ExpandoObject();
        }

        public EstimatedDVH(dynamic client)
        {
            _client = client;
        }

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CurveData"))
                        return _client.CurveData;
                    else
                        return default(DVHPoint[]);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CurveData; }
                    );
                return default(DVHPoint[]);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CurveData = value;
            }
        }

        public PlanSetup PlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanSetup"))
                        return _client.PlanSetup;
                    else
                        return default(PlanSetup);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new PlanSetup(_client.PlanSetup); }
                    );
                return default(PlanSetup);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanSetup = value;
            }
        }

        public string PlanSetupId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanSetupId"))
                        return _client.PlanSetupId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PlanSetupId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanSetupId = value;
            }
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Structure"))
                        return _client.Structure;
                    else
                        return default(Structure);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Structure(_client.Structure); }
                    );
                return default(Structure);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Structure = value;
            }
        }

        public string StructureId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StructureId"))
                        return _client.StructureId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StructureId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureId = value;
            }
        }

        public DoseValue TargetDoseLevel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TargetDoseLevel"))
                        return _client.TargetDoseLevel;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TargetDoseLevel; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TargetDoseLevel = value;
            }
        }

        public DVHEstimateType Type
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Type"))
                        return _client.Type;
                    else
                        return default(DVHEstimateType);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Type; }
                    );
                return default(DVHEstimateType);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Type = value;
                }
            }
        }
    }
}