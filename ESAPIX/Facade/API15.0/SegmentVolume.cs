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
    public class SegmentVolume : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.SegmentVolume And(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.And(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.And(other));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume AsymmetricMargin(VMS.TPS.Common.Model.Types.AxisAlignedMargins margins)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AsymmetricMargin(margins));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.AsymmetricMargin(margins));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Margin(System.Double marginInMM)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Margin(marginInMM));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Margin(marginInMM));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Not()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Not());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Not());
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Or(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Or(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Or(other));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Sub(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Sub(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Sub(other));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Xor(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Xor(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Xor(other));
            }
        }

        public SegmentVolume()
        {
            _client = (new ExpandoObject());
        }

        public SegmentVolume(dynamic client)
        {
            _client = (client);
        }
    }
}