using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class EstimatedDVH : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.DVHPoint[] CurveData
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CurveData"))
                    {
                        return _client.CurveData;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DVHPoint[]);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CurveData;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DVHPoint[]);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CurveData = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.PlanSetup PlanSetup
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanSetup"))
                    {
                        return _client.PlanSetup;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.PlanSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.PlanSetup) != (null))
                        {
                            return new ESAPIX.Facade.API.PlanSetup(_client.PlanSetup);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.PlanSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanSetup = (value);
                }
                else
                {
                }
            }
        }

        public System.String PlanSetupId
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanSetupId"))
                    {
                        return _client.PlanSetupId;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanSetupId;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanSetupId = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Structure"))
                    {
                        return _client.Structure;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Structure);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Structure) != (null))
                        {
                            return new ESAPIX.Facade.API.Structure(_client.Structure);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.Structure);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Structure = (value);
                }
                else
                {
                }
            }
        }

        public System.String StructureId
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StructureId"))
                    {
                        return _client.StructureId;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.StructureId;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StructureId = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DoseValue TargetDoseLevel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TargetDoseLevel"))
                    {
                        return _client.TargetDoseLevel;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TargetDoseLevel;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DoseValue);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TargetDoseLevel = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DVHEstimateType Type
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Type"))
                    {
                        return _client.Type;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DVHEstimateType);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Type;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DVHEstimateType);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Type = (value);
                }
                else
                {
                }
            }
        }

        public EstimatedDVH()
        {
            _client = (new ExpandoObject());
        }

        public EstimatedDVH(dynamic client)
        {
            _client = (client);
        }
    }
}