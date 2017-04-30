#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class ImageProfile : LineProfile
    {
        public ImageProfile()
        {
            _client = new ExpandoObject();
        }

        public ImageProfile(dynamic client)
        {
            _client = client;
        }

        public ImageProfile(VVector origin, VVector step, double[] data, string unit)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructImageProfile(origin, step, data, unit);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Origin = origin;
                _client.Step = step;
                _client.Data = data;
                _client.Unit = unit;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public string Unit
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Unit") ? _client.Unit : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Unit = value;
            }
        }
    }
}