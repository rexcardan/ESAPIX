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
    public class IonSpotParametersCollection : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable, System.Collections.Generic.IEnumerable<ESAPIX.Facade.API.IonSpotParameters>, System.Collections.IEnumerable
    {
        public ESAPIX.Facade.API.IonSpotParameters this[int index]
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Item"))
                    {
                        return _client[index];
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonSpotParameters);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client[index]) != (null))
                        {
                            return new ESAPIX.Facade.API.IonSpotParameters(_client[index]);
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
                    return default (ESAPIX.Facade.API.IonSpotParameters);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client[index] = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 Count
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Count"))
                    {
                        return _client.Count;
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
                        return _client.Count;
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
                    _client.Count = (value);
                }
                else
                {
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        public System.Collections.Generic.IEnumerator<ESAPIX.Facade.API.IonSpotParameters> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        public IonSpotParametersCollection()
        {
            _client = (new ExpandoObject());
        }

        public IonSpotParametersCollection(dynamic client)
        {
            _client = (client);
        }
    }
}