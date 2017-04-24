using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BeamParameters
    {
        internal dynamic _client;
        public BeamParameters() { _client = new ExpandoObject(); }
        public BeamParameters(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public IEnumerable<ESAPIX.Facade.API.ControlPointParameters> ControlPoints
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.ControlPoints;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.ControlPointParameters();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public ESAPIX.Facade.Types.GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject) { return _client.GantryDirection; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.GantryDirection>((sc) => { return (ESAPIX.Facade.Types.GantryDirection)local._client.GantryDirection; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.GantryDirection = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector Isocenter
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Isocenter; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.Isocenter); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Isocenter = value; }
            }
        }
        public System.Double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject) { return _client.WeightFactor; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.WeightFactor; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.WeightFactor = value; }
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