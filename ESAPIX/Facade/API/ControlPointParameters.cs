using System.Dynamic;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ControlPointParameters
    {
        internal dynamic _client;

        public ControlPointParameters()
        {
            _client = new ExpandoObject();
        }

        public ControlPointParameters(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double CollimatorAngle
        {
            get
            {
                if (_client is ExpandoObject) return _client.CollimatorAngle;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.CollimatorAngle; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CollimatorAngle = value;
            }
        }

        public double GantryAngle
        {
            get
            {
                if (_client is ExpandoObject) return _client.GantryAngle;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.GantryAngle; });
            }
            set
            {
                if (_client is ExpandoObject) _client.GantryAngle = value;
            }
        }

        public VRect<double> JawPositions
        {
            get
            {
                if (_client is ExpandoObject) return _client.JawPositions;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.JawPositions)) return default(VRect<double>);
                    return new VRect<double>(local._client.JawPositions);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.JawPositions = value;
            }
        }

        public float[,] LeafPositions
        {
            get
            {
                if (_client is ExpandoObject) return _client.LeafPositions;
                var local = this;
                return X.Instance.CurrentContext.GetValue<float[,]>(sc => { return local._client.LeafPositions; });
            }
            set
            {
                if (_client is ExpandoObject) _client.LeafPositions = value;
            }
        }

        public double MetersetWeight
        {
            get
            {
                if (_client is ExpandoObject) return _client.MetersetWeight;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MetersetWeight; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MetersetWeight = value;
            }
        }

        public double PatientSupportAngle
        {
            get
            {
                if (_client is ExpandoObject) return _client.PatientSupportAngle;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.PatientSupportAngle; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PatientSupportAngle = value;
            }
        }

        public double TableTopLateralPosition
        {
            get
            {
                if (_client is ExpandoObject) return _client.TableTopLateralPosition;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.TableTopLateralPosition;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TableTopLateralPosition = value;
            }
        }

        public double TableTopLongitudinalPosition
        {
            get
            {
                if (_client is ExpandoObject) return _client.TableTopLongitudinalPosition;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.TableTopLongitudinalPosition;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TableTopLongitudinalPosition = value;
            }
        }

        public double TableTopVerticalPosition
        {
            get
            {
                if (_client is ExpandoObject) return _client.TableTopVerticalPosition;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.TableTopVerticalPosition;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TableTopVerticalPosition = value;
            }
        }
    }
}