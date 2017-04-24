using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsBase
    {
        internal dynamic _client;
        public OptimizationOptionsBase() { _client = new ExpandoObject(); }
        public OptimizationOptionsBase(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String MLC
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MLC; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MLC; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MLC = value; }
            }
        }
        public ESAPIX.Facade.Types.OptimizationOption StartOption
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StartOption; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.OptimizationOption>((sc) => { return (ESAPIX.Facade.Types.OptimizationOption)local._client.StartOption; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StartOption = value; }
            }
        }
        public ESAPIX.Facade.Types.OptimizationIntermediateDoseOption IntermediateDoseOption
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IntermediateDoseOption; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.OptimizationIntermediateDoseOption>((sc) => { return (ESAPIX.Facade.Types.OptimizationIntermediateDoseOption)local._client.IntermediateDoseOption; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IntermediateDoseOption = value; }
            }
        }
    }
}