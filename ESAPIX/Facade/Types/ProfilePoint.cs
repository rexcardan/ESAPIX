#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class ProfilePoint
    {
        internal dynamic _client;

        public ProfilePoint()
        {
            _client = new ExpandoObject();
        }

        public ProfilePoint(dynamic client)
        {
            _client = client;
        }

        public ProfilePoint(VVector position, double value)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructProfilePoint(position, value);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Position = position;
                _client.Value = value;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public VVector Position
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Position") ? _client.Position : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Position)) return default(VVector);
                    return new VVector(local._client.Position);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Position = value;
            }
        }

        public double Value
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Value") ? _client.Value : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Value; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Value = value;
            }
        }
    }
}