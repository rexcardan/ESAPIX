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
    public class BeamUncertainty : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.Beam Beam
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Beam"))
                    {
                        return _client.Beam;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Beam);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Beam) != (null))
                        {
                            return new ESAPIX.Facade.API.Beam(_client.Beam);
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
                    return default (ESAPIX.Facade.API.Beam);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Beam = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.BeamNumber BeamNumber
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("BeamNumber"))
                    {
                        return _client.BeamNumber;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.BeamNumber);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.BeamNumber;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.BeamNumber);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.BeamNumber = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Dose Dose
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
                        return default (ESAPIX.Facade.API.Dose);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Dose) != (null))
                        {
                            return new ESAPIX.Facade.API.Dose(_client.Dose);
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
                    return default (ESAPIX.Facade.API.Dose);
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

        public BeamUncertainty()
        {
            _client = (new ExpandoObject());
        }

        public BeamUncertainty(dynamic client)
        {
            _client = (client);
        }
    }
}