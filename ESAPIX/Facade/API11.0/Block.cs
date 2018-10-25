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
    public class Block : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.AddOnMaterial AddOnMaterial
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("AddOnMaterial"))
                    {
                        return _client.AddOnMaterial;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.AddOnMaterial);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.AddOnMaterial) != (null))
                        {
                            return new ESAPIX.Facade.API.AddOnMaterial(_client.AddOnMaterial);
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
                    return default (ESAPIX.Facade.API.AddOnMaterial);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.AddOnMaterial = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Tray Tray
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Tray"))
                    {
                        return _client.Tray;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Tray);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Tray) != (null))
                        {
                            return new ESAPIX.Facade.API.Tray(_client.Tray);
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
                    return default (ESAPIX.Facade.API.Tray);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Tray = (value);
                }
                else
                {
                }
            }
        }

        public System.Double TransmissionFactor
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TransmissionFactor"))
                    {
                        return _client.TransmissionFactor;
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
                        return _client.TransmissionFactor;
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
                    _client.TransmissionFactor = (value);
                }
                else
                {
                }
            }
        }

        public System.Double TrayTransmissionFactor
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TrayTransmissionFactor"))
                    {
                        return _client.TrayTransmissionFactor;
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
                        return _client.TrayTransmissionFactor;
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
                    _client.TrayTransmissionFactor = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.BlockType Type
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
                        return default (VMS.TPS.Common.Model.Types.BlockType);
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
                    return default (VMS.TPS.Common.Model.Types.BlockType);
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

        public System.Boolean IsDiverging
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsDiverging"))
                    {
                        return _client.IsDiverging;
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
                        return _client.IsDiverging;
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
                    _client.IsDiverging = (value);
                }
                else
                {
                }
            }
        }

        public Block()
        {
            _client = (new ExpandoObject());
        }

        public Block(dynamic client)
        {
            _client = (client);
        }
    }
}