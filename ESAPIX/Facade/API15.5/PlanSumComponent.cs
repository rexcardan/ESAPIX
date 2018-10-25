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
    public class PlanSumComponent : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
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

        public VMS.TPS.Common.Model.Types.PlanSumOperation PlanSumOperation
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanSumOperation"))
                    {
                        return _client.PlanSumOperation;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.PlanSumOperation);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanSumOperation;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.PlanSumOperation);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanSumOperation = (value);
                }
                else
                {
                }
            }
        }

        public System.Double PlanWeight
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanWeight"))
                    {
                        return _client.PlanWeight;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PlanWeight;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanWeight = (value);
                }
                else
                {
                }
            }
        }

        public PlanSumComponent()
        {
            _client = (new ExpandoObject());
        }

        public PlanSumComponent(dynamic client)
        {
            _client = (client);
        }
    }
}