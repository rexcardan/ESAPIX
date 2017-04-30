using System.Dynamic;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizerDVH
    {
        internal dynamic _client;

        public OptimizerDVH()
        {
            _client = new ExpandoObject();
        }

        public OptimizerDVH(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject) return _client.CurveData;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DVHPoint[]>(sc =>
                {
                    return ArrayHelper.GenerateDVHPointArray(local._client.CurveData);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CurveData = value;
            }
        }

        public Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) return _client.Structure;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Structure)) return default(Structure);
                    return new Structure(local._client.Structure);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Structure = value;
            }
        }
    }
}