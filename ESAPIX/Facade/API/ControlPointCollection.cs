#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ControlPointCollection : SerializableObject, System.Xml.Serialization.IXmlSerializable,
        IEnumerable<ControlPoint>, IEnumerable
    {
        public ControlPointCollection()
        {
            _client = new List<ControlPoint>();
        }

        public ControlPointCollection(dynamic client)
        {
            _client = client;
        }

        public ControlPoint this[int index]
        {
            get
            {
                if (_client is List<ControlPoint>)
                        return _client[index];
                 
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client[index] != null)
                                return new ControlPoint(_client[index]);
                            return null;
                        }
                    );
                return default(ControlPoint);
            }

            set
            {
                if (_client is List<ControlPoint>)
                    _client[index] = value;
            }
        }

        public int Count
        {
            get
            {
                if (_client is List<ControlPoint>)           
                        return _client.Count;

                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Count; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Count = value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        public IEnumerator<ControlPoint> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return this[i];
        }
    }
}