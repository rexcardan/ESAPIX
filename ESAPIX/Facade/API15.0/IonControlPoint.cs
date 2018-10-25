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
    public class IonControlPoint : ESAPIX.Facade.API.ControlPoint, System.Xml.Serialization.IXmlSerializable
    {
        public ESAPIX.Facade.API.IonSpotCollection FinalSpotList
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FinalSpotList"))
                    {
                        return _client.FinalSpotList;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonSpotCollection);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.FinalSpotList) != (null))
                        {
                            return new ESAPIX.Facade.API.IonSpotCollection(_client.FinalSpotList);
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
                    return default (ESAPIX.Facade.API.IonSpotCollection);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.FinalSpotList = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.LateralSpreadingDeviceSettings> LateralSpreadingDeviceSettings
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("LateralSpreadingDeviceSettings"))
                    {
                        foreach (var item in _client.LateralSpreadingDeviceSettings)
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
                        var asEnum = (IEnumerable)_client.LateralSpreadingDeviceSettings;
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
                        var facade = new ESAPIX.Facade.API.LateralSpreadingDeviceSettings();
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
                    _client.LateralSpreadingDeviceSettings = value;
            }
        }

        public System.Double NominalBeamEnergy
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NominalBeamEnergy"))
                    {
                        return _client.NominalBeamEnergy;
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
                        return _client.NominalBeamEnergy;
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
                    _client.NominalBeamEnergy = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 NumberOfPaintings
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NumberOfPaintings"))
                    {
                        return _client.NumberOfPaintings;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.NumberOfPaintings;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.NumberOfPaintings = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.RangeModulatorSettings> RangeModulatorSettings
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("RangeModulatorSettings"))
                    {
                        foreach (var item in _client.RangeModulatorSettings)
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
                        var asEnum = (IEnumerable)_client.RangeModulatorSettings;
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
                        var facade = new ESAPIX.Facade.API.RangeModulatorSettings();
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
                    _client.RangeModulatorSettings = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.RangeShifterSettings> RangeShifterSettings
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("RangeShifterSettings"))
                    {
                        foreach (var item in _client.RangeShifterSettings)
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
                        var asEnum = (IEnumerable)_client.RangeShifterSettings;
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
                        var facade = new ESAPIX.Facade.API.RangeShifterSettings();
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
                    _client.RangeShifterSettings = value;
            }
        }

        public ESAPIX.Facade.API.IonSpotCollection RawSpotList
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("RawSpotList"))
                    {
                        return _client.RawSpotList;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonSpotCollection);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.RawSpotList) != (null))
                        {
                            return new ESAPIX.Facade.API.IonSpotCollection(_client.RawSpotList);
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
                    return default (ESAPIX.Facade.API.IonSpotCollection);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.RawSpotList = (value);
                }
                else
                {
                }
            }
        }

        public System.Double ScanningSpotSizeX
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ScanningSpotSizeX"))
                    {
                        return _client.ScanningSpotSizeX;
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
                        return _client.ScanningSpotSizeX;
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
                    _client.ScanningSpotSizeX = (value);
                }
                else
                {
                }
            }
        }

        public System.Double ScanningSpotSizeY
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ScanningSpotSizeY"))
                    {
                        return _client.ScanningSpotSizeY;
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
                        return _client.ScanningSpotSizeY;
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
                    _client.ScanningSpotSizeY = (value);
                }
                else
                {
                }
            }
        }

        public System.String ScanSpotTuneId
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ScanSpotTuneId"))
                    {
                        return _client.ScanSpotTuneId;
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
                        return _client.ScanSpotTuneId;
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
                    _client.ScanSpotTuneId = (value);
                }
                else
                {
                }
            }
        }

        public System.Double SnoutPosition
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SnoutPosition"))
                    {
                        return _client.SnoutPosition;
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
                        return _client.SnoutPosition;
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
                    _client.SnoutPosition = (value);
                }
                else
                {
                }
            }
        }

        public IonControlPoint()
        {
            _client = (new ExpandoObject());
        }

        public IonControlPoint(dynamic client)
        {
            _client = (client);
        }
    }
}