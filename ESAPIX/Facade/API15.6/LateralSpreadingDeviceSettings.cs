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
    public class LateralSpreadingDeviceSettings : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double IsocenterToLateralSpreadingDeviceDistance
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsocenterToLateralSpreadingDeviceDistance"))
                    {
                        return _client.IsocenterToLateralSpreadingDeviceDistance;
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
                        return _client.IsocenterToLateralSpreadingDeviceDistance;
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
                    _client.IsocenterToLateralSpreadingDeviceDistance = (value);
                }
                else
                {
                }
            }
        }

        public System.String LateralSpreadingDeviceSetting
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("LateralSpreadingDeviceSetting"))
                    {
                        return _client.LateralSpreadingDeviceSetting;
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
                        return _client.LateralSpreadingDeviceSetting;
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
                    _client.LateralSpreadingDeviceSetting = (value);
                }
                else
                {
                }
            }
        }

        public System.Double LateralSpreadingDeviceWaterEquivalentThickness
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("LateralSpreadingDeviceWaterEquivalentThickness"))
                    {
                        return _client.LateralSpreadingDeviceWaterEquivalentThickness;
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
                        return _client.LateralSpreadingDeviceWaterEquivalentThickness;
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
                    _client.LateralSpreadingDeviceWaterEquivalentThickness = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.LateralSpreadingDevice ReferencedLateralSpreadingDevice
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ReferencedLateralSpreadingDevice"))
                    {
                        return _client.ReferencedLateralSpreadingDevice;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.LateralSpreadingDevice);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.ReferencedLateralSpreadingDevice) != (null))
                        {
                            return new ESAPIX.Facade.API.LateralSpreadingDevice(_client.ReferencedLateralSpreadingDevice);
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
                    return default (ESAPIX.Facade.API.LateralSpreadingDevice);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ReferencedLateralSpreadingDevice = (value);
                }
                else
                {
                }
            }
        }

        public LateralSpreadingDeviceSettings()
        {
            _client = (new ExpandoObject());
        }

        public LateralSpreadingDeviceSettings(dynamic client)
        {
            _client = (client);
        }
    }
}