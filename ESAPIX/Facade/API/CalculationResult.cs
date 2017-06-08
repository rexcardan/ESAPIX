#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class CalculationResult
    {
        internal dynamic _client;

        public CalculationResult()
        {
            _client = new ExpandoObject();
        }

        public CalculationResult(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public bool Success
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Success"))
                        return _client.Success;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Success; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Success = value;
                }
            }
        }
    }
}