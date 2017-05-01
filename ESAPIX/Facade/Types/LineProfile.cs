#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class LineProfile
    {
        internal dynamic _client;

        public LineProfile()
        {
            _client = new ExpandoObject();
        }

        public LineProfile(dynamic client)
        {
            _client = client;
        }

        public LineProfile(VVector origin, VVector step, double[] data)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructLineProfile(origin, step, data);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public ProfilePoint this[int index]
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("this[int index]")
                        ? _client[index]
                        : default(ProfilePoint);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client[index])) return default(ProfilePoint);
                    return new ProfilePoint(local._client[index]);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client[index] = value;
            }
        }

        public int Count
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Count") ? _client.Count : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Count; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Count = value;
            }
        }
    }
}