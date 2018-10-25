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
    public class PlanningItem : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CreationDateTime"))
                    {
                        return _client.CreationDateTime;
                    }
                    else
                    {
                        return default (System.Nullable<System.DateTime>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CreationDateTime;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.DateTime>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CreationDateTime = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.PlanningItemDose Dose
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
                        return default (ESAPIX.Facade.API.PlanningItemDose);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Dose) != (null))
                        {
                            return new ESAPIX.Facade.API.PlanningItemDose(_client.Dose);
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
                    return default (ESAPIX.Facade.API.PlanningItemDose);
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

        public VMS.TPS.Common.Model.Types.DoseValuePresentation DoseValuePresentation
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DoseValuePresentation"))
                    {
                        return _client.DoseValuePresentation;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValuePresentation);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.DoseValuePresentation;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DoseValuePresentation);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.DoseValuePresentation = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.DoseValuePresentation = (value));
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Structure> StructuresSelectedForDvh
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructuresSelectedForDvh"))
                    {
                        foreach (var item in _client.StructuresSelectedForDvh)
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
                        var asEnum = (IEnumerable)_client.StructuresSelectedForDvh;
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
                        var facade = new ESAPIX.Facade.API.Structure();
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
                    _client.StructuresSelectedForDvh = value;
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

        public VMS.TPS.Common.Model.Types.DoseValue GetDoseAtVolume(ESAPIX.Facade.API.Structure structure, System.Double volume, VMS.TPS.Common.Model.Types.VolumePresentation volumePresentation, VMS.TPS.Common.Model.Types.DoseValuePresentation requestedDosePresentation)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetDoseAtVolume(structure._client, volume, volumePresentation, requestedDosePresentation));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.DoseValue)))
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }

                    return (VMS.TPS.Common.Model.Types.DoseValue)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.DoseValue)(_client.GetDoseAtVolume(structure, volume, volumePresentation, requestedDosePresentation));
            }
        }

        public System.Double GetVolumeAtDose(ESAPIX.Facade.API.Structure structure, VMS.TPS.Common.Model.Types.DoseValue dose, VMS.TPS.Common.Model.Types.VolumePresentation requestedVolumePresentation)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetVolumeAtDose(structure._client, dose, requestedVolumePresentation));
                    if (fromClient.Equals(default (System.Double)))
                    {
                        return default (System.Double);
                    }

                    return (System.Double)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Double)(_client.GetVolumeAtDose(structure, dose, requestedVolumePresentation));
            }
        }

        public PlanningItem()
        {
            _client = (new ExpandoObject());
        }

        public PlanningItem(dynamic client)
        {
            _client = (client);
        }
    }
}