using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BeamParameters
    {
        internal dynamic _client;

        public BeamParameters()
        {
            _client = new ExpandoObject();
        }

        public BeamParameters(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public IEnumerable<ControlPointParameters> ControlPoints
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.ControlPoints;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new ControlPointParameters();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject) return _client.GantryDirection;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (GantryDirection) local._client.GantryDirection;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.GantryDirection = value;
            }
        }

        public VVector Isocenter
        {
            get
            {
                if (_client is ExpandoObject) return _client.Isocenter;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Isocenter)) return default(VVector);
                    return new VVector(local._client.Isocenter);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Isocenter = value;
            }
        }

        public double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject) return _client.WeightFactor;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.WeightFactor; });
            }
            set
            {
                if (_client is ExpandoObject) _client.WeightFactor = value;
            }
        }

        public void SetAllLeafPositions(float[,] leafPositions)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetAllLeafPositions(leafPositions); });
        }

        public void SetJawPositions(VRect<double> positions)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetJawPositions(positions._client); });
        }
    }
}