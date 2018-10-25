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
    public class RangeModulatorSettings : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double IsocenterToRangeModulatorDistance
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsocenterToRangeModulatorDistance"))
                    {
                        return _client.IsocenterToRangeModulatorDistance;
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
                        return _client.IsocenterToRangeModulatorDistance;
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
                    _client.IsocenterToRangeModulatorDistance = (value);
                }
                else
                {
                }
            }
        }

        public System.Double RangeModulatorGatingStartValue
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RangeModulatorGatingStartValue"))
                    {
                        return _client.RangeModulatorGatingStartValue;
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
                        return _client.RangeModulatorGatingStartValue;
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
                    _client.RangeModulatorGatingStartValue = (value);
                }
                else
                {
                }
            }
        }

        public System.Double RangeModulatorGatingStarWaterEquivalentThickness
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RangeModulatorGatingStarWaterEquivalentThickness"))
                    {
                        return _client.RangeModulatorGatingStarWaterEquivalentThickness;
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
                        return _client.RangeModulatorGatingStarWaterEquivalentThickness;
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
                    _client.RangeModulatorGatingStarWaterEquivalentThickness = (value);
                }
                else
                {
                }
            }
        }

        public System.Double RangeModulatorGatingStopValue
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RangeModulatorGatingStopValue"))
                    {
                        return _client.RangeModulatorGatingStopValue;
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
                        return _client.RangeModulatorGatingStopValue;
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
                    _client.RangeModulatorGatingStopValue = (value);
                }
                else
                {
                }
            }
        }

        public System.Double RangeModulatorGatingStopWaterEquivalentThickness
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RangeModulatorGatingStopWaterEquivalentThickness"))
                    {
                        return _client.RangeModulatorGatingStopWaterEquivalentThickness;
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
                        return _client.RangeModulatorGatingStopWaterEquivalentThickness;
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
                    _client.RangeModulatorGatingStopWaterEquivalentThickness = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.RangeModulator ReferencedRangeModulator
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ReferencedRangeModulator"))
                    {
                        return _client.ReferencedRangeModulator;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.RangeModulator);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.ReferencedRangeModulator) != (null))
                        {
                            return new ESAPIX.Facade.API.RangeModulator(_client.ReferencedRangeModulator);
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
                    return default (ESAPIX.Facade.API.RangeModulator);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ReferencedRangeModulator = (value);
                }
                else
                {
                }
            }
        }

        public RangeModulatorSettings()
        {
            _client = (new ExpandoObject());
        }

        public RangeModulatorSettings(dynamic client)
        {
            _client = (client);
        }
    }
}