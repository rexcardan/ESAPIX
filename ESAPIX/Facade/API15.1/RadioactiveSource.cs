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
    public class RadioactiveSource : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Nullable<System.DateTime> CalibrationDate
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CalibrationDate"))
                    {
                        return _client.CalibrationDate;
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
                        return _client.CalibrationDate;
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
                    _client.CalibrationDate = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean NominalActivity
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NominalActivity"))
                    {
                        return _client.NominalActivity;
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
                        return _client.NominalActivity;
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
                    _client.NominalActivity = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.RadioactiveSourceModel RadioactiveSourceModel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RadioactiveSourceModel"))
                    {
                        return _client.RadioactiveSourceModel;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.RadioactiveSourceModel);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.RadioactiveSourceModel) != (null))
                        {
                            return new ESAPIX.Facade.API.RadioactiveSourceModel(_client.RadioactiveSourceModel);
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
                    return default (ESAPIX.Facade.API.RadioactiveSourceModel);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.RadioactiveSourceModel = (value);
                }
                else
                {
                }
            }
        }

        public System.String SerialNumber
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SerialNumber"))
                    {
                        return _client.SerialNumber;
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
                        return _client.SerialNumber;
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
                    _client.SerialNumber = (value);
                }
                else
                {
                }
            }
        }

        public System.Double Strength
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Strength"))
                    {
                        return _client.Strength;
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
                        return _client.Strength;
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
                    _client.Strength = (value);
                }
                else
                {
                }
            }
        }

        public RadioactiveSource()
        {
            _client = (new ExpandoObject());
        }

        public RadioactiveSource(dynamic client)
        {
            _client = (client);
        }
    }
}