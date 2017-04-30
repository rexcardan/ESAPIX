#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

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
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public bool Success
        {
            get
            {
                if (_client is ExpandoObject) return _client.Success;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.Success; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Success = value;
            }
        }
    }
}