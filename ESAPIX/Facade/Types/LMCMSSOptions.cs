#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class LMCMSSOptions
    {
        internal dynamic _client;

        public LMCMSSOptions()
        {
            _client = new ExpandoObject();
        }

        public LMCMSSOptions(dynamic client)
        {
            _client = client;
        }

        public LMCMSSOptions(int numberOfIterations)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructLMCMSSOptions(numberOfIterations);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.NumberOfIterations = numberOfIterations;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public int NumberOfIterations
        {
            get
            {
                if (_client is ExpandoObject) return _client.NumberOfIterations;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.NumberOfIterations; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfIterations = value;
            }
        }
    }
}