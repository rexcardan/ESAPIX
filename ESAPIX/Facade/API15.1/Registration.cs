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
    public class Registration : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CreationDateTime"))
                    {
                        return _client.CreationDateTime;
                    }
                    else
                    {
                        return default (System.Nullable<System.DateTime>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CreationDateTime;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.DateTime>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CreationDateTime = (value);
                }
                else
                {
                }
            }
        }

        public System.String RegisteredFOR
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RegisteredFOR"))
                    {
                        return _client.RegisteredFOR;
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
                        return _client.RegisteredFOR;
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
                    _client.RegisteredFOR = (value);
                }
                else
                {
                }
            }
        }

        public System.String SourceFOR
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SourceFOR"))
                    {
                        return _client.SourceFOR;
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
                        return _client.SourceFOR;
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
                    _client.SourceFOR = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.RegistrationApprovalStatus Status
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
                        return default (VMS.TPS.Common.Model.Types.RegistrationApprovalStatus);
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
                    return default (VMS.TPS.Common.Model.Types.RegistrationApprovalStatus);
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

        public System.Nullable<System.DateTime> StatusDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StatusDateTime"))
                    {
                        return _client.StatusDateTime;
                    }
                    else
                    {
                        return default (System.Nullable<System.DateTime>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.StatusDateTime;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.DateTime>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StatusDateTime = (value);
                }
                else
                {
                }
            }
        }

        public System.String StatusUserDisplayName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StatusUserDisplayName"))
                    {
                        return _client.StatusUserDisplayName;
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
                        return _client.StatusUserDisplayName;
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
                    _client.StatusUserDisplayName = (value);
                }
                else
                {
                }
            }
        }

        public System.String StatusUserName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StatusUserName"))
                    {
                        return _client.StatusUserName;
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
                        return _client.StatusUserName;
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
                    _client.StatusUserName = (value);
                }
                else
                {
                }
            }
        }

        public System.Double[,] TransformationMatrix
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TransformationMatrix"))
                    {
                        return _client.TransformationMatrix;
                    }
                    else
                    {
                        return default (System.Double[,]);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TransformationMatrix;
                    }

                    );
                }
                else
                {
                    return default (System.Double[,]);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TransformationMatrix = (value);
                }
                else
                {
                }
            }
        }

        public System.String UID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UID"))
                    {
                        return _client.UID;
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
                        return _client.UID;
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
                    _client.UID = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector InverseTransformPoint(VMS.TPS.Common.Model.Types.VVector pt)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.InverseTransformPoint(pt));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.VVector)))
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }

                    return (VMS.TPS.Common.Model.Types.VVector)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.VVector)(_client.InverseTransformPoint(pt));
            }
        }

        public VMS.TPS.Common.Model.Types.VVector TransformPoint(VMS.TPS.Common.Model.Types.VVector pt)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.TransformPoint(pt));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.VVector)))
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }

                    return (VMS.TPS.Common.Model.Types.VVector)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.VVector)(_client.TransformPoint(pt));
            }
        }

        public Registration()
        {
            _client = (new ExpandoObject());
        }

        public Registration(dynamic client)
        {
            _client = (client);
        }
    }
}