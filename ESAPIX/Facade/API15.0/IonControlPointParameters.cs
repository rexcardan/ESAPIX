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
    public class IonControlPointParameters : ESAPIX.Facade.API.ControlPointParameters
    {
        public ESAPIX.Facade.API.IonSpotParametersCollection FinalSpotList
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FinalSpotList"))
                    {
                        return _client.FinalSpotList;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonSpotParametersCollection);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.FinalSpotList) != (null))
                        {
                            return new ESAPIX.Facade.API.IonSpotParametersCollection(_client.FinalSpotList);
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
                    return default (ESAPIX.Facade.API.IonSpotParametersCollection);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.FinalSpotList = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.IonSpotParametersCollection RawSpotList
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RawSpotList"))
                    {
                        return _client.RawSpotList;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonSpotParametersCollection);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.RawSpotList) != (null))
                        {
                            return new ESAPIX.Facade.API.IonSpotParametersCollection(_client.RawSpotList);
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
                    return default (ESAPIX.Facade.API.IonSpotParametersCollection);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.RawSpotList = (value);
                }
                else
                {
                }
            }
        }

        public IonControlPointParameters()
        {
            _client = (new ExpandoObject());
        }

        public IonControlPointParameters(dynamic client)
        {
            _client = (client);
        }
    }
}