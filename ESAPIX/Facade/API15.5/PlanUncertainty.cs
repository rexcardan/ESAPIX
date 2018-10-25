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
    public class PlanUncertainty : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public IEnumerable<ESAPIX.Facade.API.BeamUncertainty> BeamUncertainties
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BeamUncertainties"))
                    {
                        foreach (var item in _client.BeamUncertainties)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.BeamUncertainties;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.BeamUncertainty();
                        XC.Instance.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        }

                        );
                        if (facade._client != null)
                        {
                            yield return facade;
                        }
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.BeamUncertainties = value;
            }
        }

        public System.Double CalibrationCurveError
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CalibrationCurveError"))
                    {
                        return _client.CalibrationCurveError;
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
                        return _client.CalibrationCurveError;
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
                    _client.CalibrationCurveError = (value);
                }
                else
                {
                }
            }
        }

        public System.String DisplayName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DisplayName"))
                    {
                        return _client.DisplayName;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.DisplayName;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.DisplayName = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Dose Dose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Dose"))
                    {
                        return _client.Dose;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Dose);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Dose) != (null))
                        {
                            return new ESAPIX.Facade.API.Dose(_client.Dose);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.Dose);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Dose = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector IsocenterShift
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsocenterShift"))
                    {
                        return _client.IsocenterShift;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsocenterShift;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.VVector);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsocenterShift = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.PlanUncertaintyType UncertaintyType
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UncertaintyType"))
                    {
                        return _client.UncertaintyType;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.PlanUncertaintyType);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.UncertaintyType;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.PlanUncertaintyType);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.UncertaintyType = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.DVHData GetDVHCumulativeData(ESAPIX.Facade.API.Structure structure, VMS.TPS.Common.Model.Types.DoseValuePresentation dosePresentation, VMS.TPS.Common.Model.Types.VolumePresentation volumePresentation, System.Double binWidth)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetDVHCumulativeData(structure._client, dosePresentation, volumePresentation, binWidth));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.DVHData(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.DVHData)(_client.GetDVHCumulativeData(structure, dosePresentation, volumePresentation, binWidth));
            }
        }

        public PlanUncertainty()
        {
            _client = (new ExpandoObject());
        }

        public PlanUncertainty(dynamic client)
        {
            _client = (client);
        }
    }
}