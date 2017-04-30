using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class LMCVOptions
    {
        internal dynamic _client;

        public LMCVOptions()
        {
            _client = new ExpandoObject();
        }

        public LMCVOptions(dynamic client)
        {
            _client = client;
        }

        public LMCVOptions(bool fixedJaws)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructLMCVOptions(fixedJaws);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.FixedJaws = fixedJaws;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public bool FixedJaws
        {
            get
            {
                if (_client is ExpandoObject) return _client.FixedJaws;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.FixedJaws; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FixedJaws = value;
            }
        }
    }
}