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
    public class RangeShifterSettings : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double IsocenterToRangeShifterDistance
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsocenterToRangeShifterDistance"))
                    {
                        return _client.IsocenterToRangeShifterDistance;
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
                        return _client.IsocenterToRangeShifterDistance;
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
                    _client.IsocenterToRangeShifterDistance = (value);
                }
                else
                {
                }
            }
        }

        public System.String RangeShifterSetting
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RangeShifterSetting"))
                    {
                        return _client.RangeShifterSetting;
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
                        return _client.RangeShifterSetting;
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
                    _client.RangeShifterSetting = (value);
                }
                else
                {
                }
            }
        }

        public System.Double RangeShifterWaterEquivalentThickness
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RangeShifterWaterEquivalentThickness"))
                    {
                        return _client.RangeShifterWaterEquivalentThickness;
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
                        return _client.RangeShifterWaterEquivalentThickness;
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
                    _client.RangeShifterWaterEquivalentThickness = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.RangeShifter ReferencedRangeShifter
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ReferencedRangeShifter"))
                    {
                        return _client.ReferencedRangeShifter;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.RangeShifter);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.ReferencedRangeShifter) != (null))
                        {
                            return new ESAPIX.Facade.API.RangeShifter(_client.ReferencedRangeShifter);
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
                    return default (ESAPIX.Facade.API.RangeShifter);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ReferencedRangeShifter = (value);
                }
                else
                {
                }
            }
        }

        public RangeShifterSettings()
        {
            _client = (new ExpandoObject());
        }

        public RangeShifterSettings(dynamic client)
        {
            _client = (client);
        }
    }
}