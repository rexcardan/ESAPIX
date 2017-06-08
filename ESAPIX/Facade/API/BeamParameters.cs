#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

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
                        foreach (var item in _client.ControlPoints)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.ControlPoints;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new ControlPointParameters();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ControlPoints = value;
            }
        }

        public GantryDirection GantryDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("GantryDirection"))
                        return _client.GantryDirection;
                    else
                        return default(GantryDirection);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.GantryDirection; }
                    );
                return default(GantryDirection);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.GantryDirection = value;
            }
        }

        public VVector Isocenter
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Isocenter"))
                        return _client.Isocenter;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Isocenter; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Isocenter = value;
            }
        }

        public double WeightFactor
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("WeightFactor"))
                        return _client.WeightFactor;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.WeightFactor; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.WeightFactor = value;
            }
        }

        public void SetAllLeafPositions(float[,] leafPositions)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetAllLeafPositions(leafPositions); }
                );
            else
                _client.SetAllLeafPositions(leafPositions);
        }

        public void SetJawPositions(VRect<double> positions)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetJawPositions(positions); }
                );
            else
                _client.SetJawPositions(positions);
        }
    }
}