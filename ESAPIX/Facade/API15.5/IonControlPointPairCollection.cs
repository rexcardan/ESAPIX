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
    public class IonControlPointPairCollection : System.Collections.Generic.IEnumerable<ESAPIX.Facade.API.IonControlPointPair>, System.Collections.IEnumerable
    {
        internal dynamic _client;

        public ESAPIX.Facade.API.IonControlPointPair this[int index]
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
                        return default (ESAPIX.Facade.API.IonControlPointPair);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client[index]) != (null))
                        {
                            return new ESAPIX.Facade.API.IonControlPointPair(_client[index]);
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
                    return default (ESAPIX.Facade.API.IonControlPointPair);
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

        public System.Collections.Generic.IEnumerator<ESAPIX.Facade.API.IonControlPointPair> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        public IonControlPointPairCollection()
        {
            _client = (new ExpandoObject());
        }

        public IonControlPointPairCollection(dynamic client)
        {
            _client = (client);
        }
    }
}