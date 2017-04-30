#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public IEnumerable<ControlPointParameters> ControlPoints
        {
            get
            {
                if (_client is ExpandoObject)
                    if ((_client as ExpandoObject).HasProperty("ControlPoints"))
                        foreach (var item in _client.ControlPoints) yield return item;
                    else yield break;
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
            set
            {
                if (_client is ExpandoObject) _client.ControlPoints = value;
            }
        }

        public Types.GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("GantryDirection")
                        ? _client.GantryDirection
                        : default(Types.GantryDirection);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (Types.GantryDirection) local._client.GantryDirection;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.GantryDirection = value;
            }
        }

        public Types.VVector Isocenter
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Isocenter")
                        ? _client.Isocenter
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Isocenter)) return default(Types.VVector);
                    return new Types.VVector(local._client.Isocenter);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("WeightFactor")
                        ? _client.WeightFactor
                        : default(double);
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

        public void SetJawPositions(Types.VRect<double> positions)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetJawPositions(positions._client); });
        }
    }
}