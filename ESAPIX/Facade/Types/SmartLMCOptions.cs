using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class SmartLMCOptions
    {
        internal dynamic _client;
        public SmartLMCOptions() { _client = new ExpandoObject(); }
        public SmartLMCOptions(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public SmartLMCOptions(System.Boolean fixedFieldBorders, System.Boolean jawTracking)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructSmartLMCOptions(fixedFieldBorders, jawTracking); });
            else
            {
                _client = new ExpandoObject();
                _client.FixedFieldBorders = fixedFieldBorders;
                _client.JawTracking = jawTracking;
            }
        }
        public System.Boolean FixedFieldBorders
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FixedFieldBorders; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.FixedFieldBorders; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FixedFieldBorders = value; }
            }
        }
        public System.Boolean JawTracking
        {
            get
            {
                if (_client is ExpandoObject) { return _client.JawTracking; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.JawTracking; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.JawTracking = value; }
            }
        }
    }
}