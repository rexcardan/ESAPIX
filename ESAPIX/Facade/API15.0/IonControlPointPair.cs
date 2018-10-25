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
    public class IonControlPointPair
    {
        internal dynamic _client;
        public bool IsLive
        {
            get
            {
                return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject);
            }
        }

        public ESAPIX.Facade.API.IonControlPointParameters EndControlPoint
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("EndControlPoint"))
                    {
                        return _client.EndControlPoint;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonControlPointParameters);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.EndControlPoint) != (null))
                        {
                            return new ESAPIX.Facade.API.IonControlPointParameters(_client.EndControlPoint);
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
                    return default (ESAPIX.Facade.API.IonControlPointParameters);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.EndControlPoint = (value);
                }
                else
                {
                }
            }
        }

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

        public System.Double NominalBeamEnergy
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NominalBeamEnergy"))
                    {
                        return _client.NominalBeamEnergy;
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
                        return _client.NominalBeamEnergy;
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
                    _client.NominalBeamEnergy = (value);
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

        public ESAPIX.Facade.API.IonControlPointParameters StartControlPoint
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StartControlPoint"))
                    {
                        return _client.StartControlPoint;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonControlPointParameters);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.StartControlPoint) != (null))
                        {
                            return new ESAPIX.Facade.API.IonControlPointParameters(_client.StartControlPoint);
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
                    return default (ESAPIX.Facade.API.IonControlPointParameters);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StartControlPoint = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 StartIndex
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StartIndex"))
                    {
                        return _client.StartIndex;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.StartIndex;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StartIndex = (value);
                }
                else
                {
                }
            }
        }

        public IonControlPointPair()
        {
            _client = (new ExpandoObject());
        }

        public IonControlPointPair(dynamic client)
        {
            _client = (client);
        }
    }
}