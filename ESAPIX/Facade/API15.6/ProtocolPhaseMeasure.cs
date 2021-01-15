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
    public class ProtocolPhaseMeasure : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double TargetValue
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TargetValue"))
                    {
                        return _client.TargetValue;
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
                        return _client.TargetValue;
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
                    _client.TargetValue = (value);
                }
                else
                {
                }
            }
        }

        public System.Double ActualValue
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ActualValue"))
                    {
                        return _client.ActualValue;
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
                        return _client.ActualValue;
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
                    _client.ActualValue = (value);
                }
                else
                {
                }
            }
        }

        public System.Nullable<System.Boolean> TargetIsMet
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TargetIsMet"))
                    {
                        return _client.TargetIsMet;
                    }
                    else
                    {
                        return default (System.Nullable<System.Boolean>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TargetIsMet;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.Boolean>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TargetIsMet = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.MeasureModifier Modifier
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Modifier"))
                    {
                        return _client.Modifier;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.MeasureModifier);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Modifier;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.MeasureModifier);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Modifier = (value);
                }
                else
                {
                }
            }
        }

        public System.String StructureId
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StructureId"))
                    {
                        return _client.StructureId;
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
                        return _client.StructureId;
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
                    _client.StructureId = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.MeasureType Type
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Type"))
                    {
                        return _client.Type;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.MeasureType);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Type;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.MeasureType);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Type = (value);
                }
                else
                {
                }
            }
        }

        public System.String TypeText
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TypeText"))
                    {
                        return _client.TypeText;
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
                        return _client.TypeText;
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
                    _client.TypeText = (value);
                }
                else
                {
                }
            }
        }

        public ProtocolPhaseMeasure()
        {
            _client = (new ExpandoObject());
        }

        public ProtocolPhaseMeasure(dynamic client)
        {
            _client = (client);
        }
    }
}