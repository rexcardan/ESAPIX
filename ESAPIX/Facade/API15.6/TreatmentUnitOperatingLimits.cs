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
    public class TreatmentUnitOperatingLimits : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.TreatmentUnitOperatingLimit CollimatorAngle
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CollimatorAngle"))
                    {
                        return _client.CollimatorAngle;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.CollimatorAngle) != (null))
                        {
                            return new ESAPIX.Facade.API.TreatmentUnitOperatingLimit(_client.CollimatorAngle);
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
                    return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CollimatorAngle = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.TreatmentUnitOperatingLimit GantryAngle
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("GantryAngle"))
                    {
                        return _client.GantryAngle;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.GantryAngle) != (null))
                        {
                            return new ESAPIX.Facade.API.TreatmentUnitOperatingLimit(_client.GantryAngle);
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
                    return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.GantryAngle = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.TreatmentUnitOperatingLimit MU
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MU"))
                    {
                        return _client.MU;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.MU) != (null))
                        {
                            return new ESAPIX.Facade.API.TreatmentUnitOperatingLimit(_client.MU);
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
                    return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.MU = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.TreatmentUnitOperatingLimit PatientSupportAngle
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PatientSupportAngle"))
                    {
                        return _client.PatientSupportAngle;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.PatientSupportAngle) != (null))
                        {
                            return new ESAPIX.Facade.API.TreatmentUnitOperatingLimit(_client.PatientSupportAngle);
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
                    return default (ESAPIX.Facade.API.TreatmentUnitOperatingLimit);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PatientSupportAngle = (value);
                }
                else
                {
                }
            }
        }

        public TreatmentUnitOperatingLimits()
        {
            _client = (new ExpandoObject());
        }

        public TreatmentUnitOperatingLimits(dynamic client)
        {
            _client = (client);
        }
    }
}