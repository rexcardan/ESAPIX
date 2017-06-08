#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

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
                    if (((ExpandoObject) _client).HasProperty("CurveData"))
                        return _client.CurveData;
                    else
                        return default(DVHPoint[]);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CurveData; }
                    );
                return default(DVHPoint[]);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CurveData = value;
            }
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
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Structure(_client.Structure); }
                    );
                return default(Structure);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Structure = value;
                }
            }
        }
    }
}