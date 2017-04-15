using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BeamParameters
    {
        internal dynamic _client;
        public BeamParameters() { }
        public BeamParameters(dynamic client) { _client = client; }
        public IEnumerable<ESAPIX.Facade.API.ControlPointParameters> ControlPoints
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.ControlPointParameters>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.ControlPoints).Select(s => new ESAPIX.Facade.API.ControlPointParameters(s));
                });
            }
        }
        public ESAPIX.Facade.Types.GantryDirection GantryDirection
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.GantryDirection)local._client.GantryDirection;
            }
        }
        public ESAPIX.Facade.Types.VVector Isocenter
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.Isocenter);
            }
        }
        public System.Double WeightFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.WeightFactor; });
            }
        }
        public void SetAllLeafPositions(System.Single[,] leafPositions)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetAllLeafPositions(leafPositions);
            });

        }
        public void SetJawPositions(ESAPIX.Facade.Types.VRect<System.Double> positions)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetJawPositions(positions._client);
            });

        }
    }
}