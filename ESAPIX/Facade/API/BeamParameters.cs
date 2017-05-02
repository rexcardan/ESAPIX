#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
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
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public IEnumerable<ControlPointParameters> ControlPoints
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ControlPoints"))
                        foreach (var item in _client.ControlPoints) yield return item;
                    else yield break;
                }
                else
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
            set
            {
                if (_client is ExpandoObject) _client.ControlPoints = value;
            }
        }

        public GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("GantryDirection")
                        ? _client.GantryDirection
                        : default(GantryDirection);
                var local = this;
                return X.Instance.CurrentContext.GetValue<GantryDirection>(sc =>
                {
                    return local._client.GantryDirection;
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Isocenter") ? _client.Isocenter : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.Isocenter; });
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

        public void SetJawPositions(VRect<double> positions)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetJawPositions(positions); });
        }
    }
}