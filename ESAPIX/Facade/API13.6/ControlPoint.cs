using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class ControlPoint : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double CollimatorAngle
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CollimatorAngle"))
                    {
                        return _client.CollimatorAngle;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CollimatorAngle;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CollimatorAngle = (value);
                }
                else
                {
                }
            }
        }

        public System.Double GantryAngle
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("GantryAngle"))
                    {
                        return _client.GantryAngle;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.GantryAngle;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.GantryAngle = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VRect<System.Double> JawPositions
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("JawPositions"))
                    {
                        return _client.JawPositions;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.VRect<System.Double>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.JawPositions;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.VRect<System.Double>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.JawPositions = (value);
                }
                else
                {
                }
            }
        }

        public System.Single[,] LeafPositions
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("LeafPositions"))
                    {
                        return _client.LeafPositions;
                    }
                    else
                    {
                        return default (System.Single[,]);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.LeafPositions;
                    }

                    );
                }
                else
                {
                    return default (System.Single[,]);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.LeafPositions = (value);
                }
                else
                {
                }
            }
        }

        public System.Double MetersetWeight
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MetersetWeight"))
                    {
                        return _client.MetersetWeight;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.MetersetWeight;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.MetersetWeight = (value);
                }
                else
                {
                }
            }
        }

        public System.Double PatientSupportAngle
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PatientSupportAngle"))
                    {
                        return _client.PatientSupportAngle;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PatientSupportAngle;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PatientSupportAngle = (value);
                }
                else
                {
                }
            }
        }

        public System.Double TableTopLateralPosition
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TableTopLateralPosition"))
                    {
                        return _client.TableTopLateralPosition;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TableTopLateralPosition;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TableTopLateralPosition = (value);
                }
                else
                {
                }
            }
        }

        public System.Double TableTopLongitudinalPosition
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TableTopLongitudinalPosition"))
                    {
                        return _client.TableTopLongitudinalPosition;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TableTopLongitudinalPosition;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TableTopLongitudinalPosition = (value);
                }
                else
                {
                }
            }
        }

        public System.Double TableTopVerticalPosition
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TableTopVerticalPosition"))
                    {
                        return _client.TableTopVerticalPosition;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.TableTopVerticalPosition;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.TableTopVerticalPosition = (value);
                }
                else
                {
                }
            }
        }

        public ControlPoint()
        {
            _client = (new ExpandoObject());
        }

        public ControlPoint(dynamic client)
        {
            _client = (client);
        }
    }
}