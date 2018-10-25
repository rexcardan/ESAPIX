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
    public class ApplicationScript : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.ApplicationScriptApprovalStatus ApprovalStatus
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ApprovalStatus"))
                    {
                        return _client.ApprovalStatus;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.ApplicationScriptApprovalStatus);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ApprovalStatus;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.ApplicationScriptApprovalStatus);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ApprovalStatus = (value);
                }
                else
                {
                }
            }
        }

        public System.String ApprovalStatusDisplayText
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ApprovalStatusDisplayText"))
                    {
                        return _client.ApprovalStatusDisplayText;
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
                        return _client.ApprovalStatusDisplayText;
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
                    _client.ApprovalStatusDisplayText = (value);
                }
                else
                {
                }
            }
        }

        public System.Reflection.AssemblyName AssemblyName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("AssemblyName"))
                    {
                        return _client.AssemblyName;
                    }
                    else
                    {
                        return default (System.Reflection.AssemblyName);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.AssemblyName;
                    }

                    );
                }
                else
                {
                    return default (System.Reflection.AssemblyName);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.AssemblyName = (value);
                }
                else
                {
                }
            }
        }

        public System.Nullable<System.DateTime> ExpirationDate
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ExpirationDate"))
                    {
                        return _client.ExpirationDate;
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
                        return _client.ExpirationDate;
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
                    _client.ExpirationDate = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsReadOnlyScript
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsReadOnlyScript"))
                    {
                        return _client.IsReadOnlyScript;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsReadOnlyScript;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsReadOnlyScript = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsWriteableScript
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsWriteableScript"))
                    {
                        return _client.IsWriteableScript;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsWriteableScript;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsWriteableScript = (value);
                }
                else
                {
                }
            }
        }

        public System.String PublisherName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PublisherName"))
                    {
                        return _client.PublisherName;
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
                        return _client.PublisherName;
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
                    _client.PublisherName = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.ApplicationScriptType ScriptType
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ScriptType"))
                    {
                        return _client.ScriptType;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.ApplicationScriptType);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ScriptType;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.ApplicationScriptType);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ScriptType = (value);
                }
                else
                {
                }
            }
        }

        public System.Nullable<System.DateTime> StatusDate
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StatusDate"))
                    {
                        return _client.StatusDate;
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
                        return _client.StatusDate;
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
                    _client.StatusDate = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.UserIdentity StatusUserIdentity
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StatusUserIdentity"))
                    {
                        return _client.StatusUserIdentity;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.UserIdentity);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.StatusUserIdentity;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.UserIdentity);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StatusUserIdentity = (value);
                }
                else
                {
                }
            }
        }

        public ApplicationScript()
        {
            _client = (new ExpandoObject());
        }

        public ApplicationScript(dynamic client)
        {
            _client = (client);
        }
    }
}