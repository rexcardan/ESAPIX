#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizerObjectiveValue
    {
        internal dynamic _client;

        public OptimizerObjectiveValue()
        {
            _client = new ExpandoObject();
        }

        public OptimizerObjectiveValue(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Structure"))
                        return _client.Structure;
                    else
                        return default(Structure);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Structure != null)
                                return new Structure(_client.Structure);
                            return null;
                        }
                    );
                return default(Structure);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Structure = value;
            }
        }

        public double Value
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Value"))
                        return _client.Value;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Value; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Value = value;
                }
            }
        }
    }
}