#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ControlPoint : SerializableObject
    {
        public ControlPoint()
        {
            _client = new ExpandoObject();
        }

        public ControlPoint(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double CollimatorAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CollimatorAngle")
                        ? _client.CollimatorAngle
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("GantryAngle")
                        ? _client.GantryAngle
                        : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.GantryAngle; });
            }
            set
            {
                if (_client is ExpandoObject) _client.GantryAngle = value;
            }
        }

        public Types.VRect<double> JawPositions
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("JawPositions")
                        ? _client.JawPositions
                        : default(Types.VRect<double>);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.JawPositions)) return default(Types.VRect<double>);
                    return new Types.VRect<double>(local._client.JawPositions);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("LeafPositions")
                        ? _client.LeafPositions
                        : default(float[,]);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MetersetWeight")
                        ? _client.MetersetWeight
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PatientSupportAngle")
                        ? _client.PatientSupportAngle
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TableTopLateralPosition")
                        ? _client.TableTopLateralPosition
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TableTopLongitudinalPosition")
                        ? _client.TableTopLongitudinalPosition
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TableTopVerticalPosition")
                        ? _client.TableTopVerticalPosition
                        : default(double);
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

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}