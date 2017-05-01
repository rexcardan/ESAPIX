#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
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
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructLMCMSSOptions(numberOfIterations);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public int NumberOfIterations
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("NumberOfIterations")
                        ? _client.NumberOfIterations
                        : default(int);
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