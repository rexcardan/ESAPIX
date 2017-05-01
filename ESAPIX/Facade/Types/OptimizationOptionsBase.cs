#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class OptimizationOptionsBase
    {
        internal dynamic _client;

        public OptimizationOptionsBase()
        {
            _client = new ExpandoObject();
        }

        public OptimizationOptionsBase(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public string MLC
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MLC") ? _client.MLC : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MLC; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MLC = value;
            }
        }

        public OptimizationOption StartOption
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StartOption")
                        ? _client.StartOption
                        : default(OptimizationOption);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (OptimizationOption) local._client.StartOption;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.StartOption = value;
            }
        }

        public OptimizationIntermediateDoseOption IntermediateDoseOption
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IntermediateDoseOption")
                        ? _client.IntermediateDoseOption
                        : default(OptimizationIntermediateDoseOption);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (OptimizationIntermediateDoseOption) local._client.IntermediateDoseOption;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.IntermediateDoseOption = value;
            }
        }
    }
}