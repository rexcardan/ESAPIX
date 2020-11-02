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
    public class PlanTreatmentSession : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
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

        public VMS.TPS.Common.Model.Types.TreatmentSessionStatus Status
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Status"))
                    {
                        return _client.Status;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.TreatmentSessionStatus);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Status;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.TreatmentSessionStatus);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Status = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.TreatmentSession TreatmentSession
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentSession"))
                    {
                        return _client.TreatmentSession;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.TreatmentSession);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.TreatmentSession) != (null))
                        {
                            return new ESAPIX.Facade.API.TreatmentSession(_client.TreatmentSession);
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
                    return default (ESAPIX.Facade.API.TreatmentSession);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TreatmentSession = (value);
                }
                else
                {
                }
            }
        }

        public PlanTreatmentSession()
        {
            _client = (new ExpandoObject());
        }

        public PlanTreatmentSession(dynamic client)
        {
            _client = (client);
        }
    }
}