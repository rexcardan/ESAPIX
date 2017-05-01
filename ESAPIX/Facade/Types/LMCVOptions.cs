#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructLMCVOptions(fixedJaws);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public bool FixedJaws
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("FixedJaws") ? _client.FixedJaws : default(bool);
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