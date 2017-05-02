#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CurveData")
                        ? _client.CurveData
                        : default(DVHPoint[]);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DVHPoint[]>(sc => { return local._client.CurveData; });
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Structure") ? _client.Structure : default(Structure);
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