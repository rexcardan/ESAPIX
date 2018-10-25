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
    public class Compensator : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
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

        public ESAPIX.Facade.API.Slot Slot
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Slot"))
                    {
                        return _client.Slot;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Slot);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Slot) != (null))
                        {
                            return new ESAPIX.Facade.API.Slot(_client.Slot);
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
                    return default (ESAPIX.Facade.API.Slot);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Slot = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.AddOnMaterial Material
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Material"))
                    {
                        return _client.Material;
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
                        if ((_client.Material) != (null))
                        {
                            return new ESAPIX.Facade.API.AddOnMaterial(_client.Material);
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
                    _client.Material = (value);
                }
                else
                {
                }
            }
        }

        public Compensator()
        {
            _client = (new ExpandoObject());
        }

        public Compensator(dynamic client)
        {
            _client = (client);
        }
    }
}