using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizerDVH
    {
        internal dynamic _client;
        public OptimizerDVH() { _client = new ExpandoObject(); }
        public OptimizerDVH(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CurveData; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DVHPoint[]>((sc) => { return ArrayHelper.GenerateDVHPointArray(local._client.CurveData); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CurveData = value; }
            }
        }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Structure; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Structure>((sc) => { return new ESAPIX.Facade.API.Structure(local._client.Structure); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Structure = value; }
            }
        }
    }
}