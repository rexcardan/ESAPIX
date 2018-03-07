using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class IonSpotParameters : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Single Weight
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Weight"))
                    {
                        return _client.Weight;
                    }
                    else
                    {
                        return default (System.Single);
                    }
                }
                else if ((XC.Instance.CurrentContext) != (null))
                {
                    return XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.Weight;
                    }

                    );
                }
                else
                {
                    return default (System.Single);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Weight = (value);
                }
                else
                {
                }
            }
        }

        public System.Single X
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("X"))
                    {
                        return _client.X;
                    }
                    else
                    {
                        return default (System.Single);
                    }
                }
                else if ((XC.Instance.CurrentContext) != (null))
                {
                    return XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.X;
                    }

                    );
                }
                else
                {
                    return default (System.Single);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.X = (value);
                }
                else
                {
                }
            }
        }

        public System.Single Y
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Y"))
                    {
                        return _client.Y;
                    }
                    else
                    {
                        return default (System.Single);
                    }
                }
                else if ((XC.Instance.CurrentContext) != (null))
                {
                    return XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.Y;
                    }

                    );
                }
                else
                {
                    return default (System.Single);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Y = (value);
                }
                else
                {
                }
            }
        }

        public IonSpotParameters()
        {
            _client = (new ExpandoObject());
        }

        public IonSpotParameters(dynamic client)
        {
            _client = (client);
        }
    }
}