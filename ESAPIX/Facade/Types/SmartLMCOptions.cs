#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class SmartLMCOptions
    {
        internal dynamic _client;

        public SmartLMCOptions()
        {
            _client = new ExpandoObject();
        }

        public SmartLMCOptions(dynamic client)
        {
            _client = client;
        }

        public SmartLMCOptions(bool fixedFieldBorders, bool jawTracking)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructSmartLMCOptions(fixedFieldBorders, jawTracking);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.FixedFieldBorders = fixedFieldBorders;
                _client.JawTracking = jawTracking;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public bool FixedFieldBorders
        {
            get
            {
                if (_client is ExpandoObject) return _client.FixedFieldBorders;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.FixedFieldBorders; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FixedFieldBorders = value;
            }
        }

        public bool JawTracking
        {
            get
            {
                if (_client is ExpandoObject) return _client.JawTracking;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.JawTracking; });
            }
            set
            {
                if (_client is ExpandoObject) _client.JawTracking = value;
            }
        }
    }
}