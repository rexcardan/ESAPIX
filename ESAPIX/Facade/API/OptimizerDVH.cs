using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizerDVH
    {
        internal dynamic _client;
        public OptimizerDVH() { }
        public OptimizerDVH(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.DVHPoint[] CurveData
        {
            get
            {
                var local = this;
                return ArrayHelper.GenerateDVHPointArray(local._client.CurveData);
            }
        }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Structure(local._client.Structure);
            }
        }
    }
}