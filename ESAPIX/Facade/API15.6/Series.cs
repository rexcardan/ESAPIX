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
    public class Series : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.String FOR
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FOR"))
                    {
                        return _client.FOR;
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
                        return _client.FOR;
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
                    _client.FOR = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Image> Images
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Images"))
                    {
                        foreach (var item in _client.Images)
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
                        var asEnum = (IEnumerable)_client.Images;
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
                        var facade = new ESAPIX.Facade.API.Image();
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
                    _client.Images = value;
            }
        }

        public System.String ImagingDeviceId
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ImagingDeviceId"))
                    {
                        return _client.ImagingDeviceId;
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
                        return _client.ImagingDeviceId;
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
                    _client.ImagingDeviceId = (value);
                }
                else
                {
                }
            }
        }

        public System.String ImagingDeviceManufacturer
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ImagingDeviceManufacturer"))
                    {
                        return _client.ImagingDeviceManufacturer;
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
                        return _client.ImagingDeviceManufacturer;
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
                    _client.ImagingDeviceManufacturer = (value);
                }
                else
                {
                }
            }
        }

        public System.String ImagingDeviceModel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ImagingDeviceModel"))
                    {
                        return _client.ImagingDeviceModel;
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
                        return _client.ImagingDeviceModel;
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
                    _client.ImagingDeviceModel = (value);
                }
                else
                {
                }
            }
        }

        public System.String ImagingDeviceSerialNo
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ImagingDeviceSerialNo"))
                    {
                        return _client.ImagingDeviceSerialNo;
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
                        return _client.ImagingDeviceSerialNo;
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
                    _client.ImagingDeviceSerialNo = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.SeriesModality Modality
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Modality"))
                    {
                        return _client.Modality;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.SeriesModality);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Modality;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.SeriesModality);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Modality = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Study Study
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Study"))
                    {
                        return _client.Study;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Study);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Study) != (null))
                        {
                            return new ESAPIX.Facade.API.Study(_client.Study);
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
                    return default (ESAPIX.Facade.API.Study);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Study = (value);
                }
                else
                {
                }
            }
        }

        public System.String UID
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UID"))
                    {
                        return _client.UID;
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
                        return _client.UID;
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
                    _client.UID = (value);
                }
                else
                {
                }
            }
        }

        public void SetImagingDevice(System.String imagingDeviceId)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetImagingDevice(imagingDeviceId);
                }

                );
            }
            else
            {
                _client.SetImagingDevice(imagingDeviceId);
            }
        }

        public Series()
        {
            _client = (new ExpandoObject());
        }

        public Series(dynamic client)
        {
            _client = (client);
        }
    }
}