#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ControlPoint : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public ControlPoint()
        {
            _client = new ExpandoObject();
        }

        public ControlPoint(dynamic client)
        {
            _client = client;
        }

        public double CollimatorAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CollimatorAngle"))
                        return _client.CollimatorAngle;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CollimatorAngle; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CollimatorAngle = value;
            }
        }

        public double GantryAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("GantryAngle"))
                        return _client.GantryAngle;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.GantryAngle; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.GantryAngle = value;
            }
        }

        public VRect<double> JawPositions
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("JawPositions"))
                        return _client.JawPositions;
                    else
                        return default(VRect<double>);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.JawPositions; }
                    );
                return default(VRect<double>);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.JawPositions = value;
            }
        }

        public float[,] LeafPositions
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("LeafPositions"))
                        return _client.LeafPositions;
                    else
                        return default(float[,]);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.LeafPositions; }
                    );
                return default(float[,]);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.LeafPositions = value;
            }
        }

        public double MetersetWeight
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MetersetWeight"))
                        return _client.MetersetWeight;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MetersetWeight; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MetersetWeight = value;
            }
        }

        public double PatientSupportAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PatientSupportAngle"))
                        return _client.PatientSupportAngle;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PatientSupportAngle; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PatientSupportAngle = value;
            }
        }

        public double TableTopLateralPosition
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TableTopLateralPosition"))
                        return _client.TableTopLateralPosition;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TableTopLateralPosition; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TableTopLateralPosition = value;
            }
        }

        public double TableTopLongitudinalPosition
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TableTopLongitudinalPosition"))
                        return _client.TableTopLongitudinalPosition;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TableTopLongitudinalPosition; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TableTopLongitudinalPosition = value;
            }
        }

        public double TableTopVerticalPosition
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TableTopVerticalPosition"))
                        return _client.TableTopVerticalPosition;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TableTopVerticalPosition; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.TableTopVerticalPosition = value;
                }
            }
        }
    }
}