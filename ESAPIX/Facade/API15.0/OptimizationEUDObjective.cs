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
    public class OptimizationEUDObjective : ESAPIX.Facade.API.OptimizationObjective, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.DoseValue Dose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Dose"))
                    {
                        return _client.Dose;
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
                        return _client.Dose;
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
                    _client.Dose = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator Operator
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Operator"))
                    {
                        return _client.Operator;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Operator;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.OptimizationObjectiveOperator);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Operator = (value);
                }
                else
                {
                }
            }
        }

        public System.Double ParameterA
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ParameterA"))
                    {
                        return _client.ParameterA;
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
                        return _client.ParameterA;
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
                    _client.ParameterA = (value);
                }
                else
                {
                }
            }
        }

        public System.Double Priority
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Priority"))
                    {
                        return _client.Priority;
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
                        return _client.Priority;
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
                    _client.Priority = (value);
                }
                else
                {
                }
            }
        }

        public OptimizationEUDObjective()
        {
            _client = (new ExpandoObject());
        }

        public OptimizationEUDObjective(dynamic client)
        {
            _client = (client);
        }
    }
}