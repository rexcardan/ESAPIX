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
    public class User : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.String Id
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Id"))
                    {
                        return _client.Id;
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
                        return _client.Id;
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
                    _client.Id = (value);
                }
                else
                {
                }
            }
        }

        public System.String Language
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Language"))
                    {
                        return _client.Language;
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
                        return _client.Language;
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
                    _client.Language = (value);
                }
                else
                {
                }
            }
        }

        public System.String Name
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Name"))
                    {
                        return _client.Name;
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
                        return _client.Name;
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
                    _client.Name = (value);
                }
                else
                {
                }
            }
        }

        public User()
        {
            _client = (new ExpandoObject());
        }

        public User(dynamic client)
        {
            _client = (client);
        }
    }
}