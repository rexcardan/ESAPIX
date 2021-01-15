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
    public class OptimizationNormalTissueParameter : ESAPIX.Facade.API.OptimizationParameter, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double DistanceFromTargetBorderInMM
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DistanceFromTargetBorderInMM"))
                    {
                        return _client.DistanceFromTargetBorderInMM;
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
                        return _client.DistanceFromTargetBorderInMM;
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
                    _client.DistanceFromTargetBorderInMM = (value);
                }
                else
                {
                }
            }
        }

        public System.Double EndDosePercentage
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("EndDosePercentage"))
                    {
                        return _client.EndDosePercentage;
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
                        return _client.EndDosePercentage;
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
                    _client.EndDosePercentage = (value);
                }
                else
                {
                }
            }
        }

        public System.Double FallOff
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FallOff"))
                    {
                        return _client.FallOff;
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
                        return _client.FallOff;
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
                    _client.FallOff = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsAutomatic
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsAutomatic"))
                    {
                        return _client.IsAutomatic;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsAutomatic;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsAutomatic = (value);
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

        public System.Double StartDosePercentage
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StartDosePercentage"))
                    {
                        return _client.StartDosePercentage;
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
                        return _client.StartDosePercentage;
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
                    _client.StartDosePercentage = (value);
                }
                else
                {
                }
            }
        }

        public OptimizationNormalTissueParameter()
        {
            _client = (new ExpandoObject());
        }

        public OptimizationNormalTissueParameter(dynamic client)
        {
            _client = (client);
        }
    }
}