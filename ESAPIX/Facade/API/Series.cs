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
    public class Series : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Series()
        {
            _client = new ExpandoObject();
        }

        public Series(dynamic client)
        {
            _client = client;
        }

        public string FOR
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("FOR"))
                        return _client.FOR;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.FOR; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.FOR = value;
            }
        }

        public IEnumerable<Image> Images
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Images"))
                        foreach (var item in _client.Images)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Images;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Image();
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
                    _client.Images = value;
            }
        }

        public string ImagingDeviceId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ImagingDeviceId"))
                        return _client.ImagingDeviceId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ImagingDeviceId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ImagingDeviceId = value;
            }
        }

        public string ImagingDeviceManufacturer
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ImagingDeviceManufacturer"))
                        return _client.ImagingDeviceManufacturer;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ImagingDeviceManufacturer; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ImagingDeviceManufacturer = value;
            }
        }

        public string ImagingDeviceModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ImagingDeviceModel"))
                        return _client.ImagingDeviceModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ImagingDeviceModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ImagingDeviceModel = value;
            }
        }

        public string ImagingDeviceSerialNo
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ImagingDeviceSerialNo"))
                        return _client.ImagingDeviceSerialNo;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ImagingDeviceSerialNo; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ImagingDeviceSerialNo = value;
            }
        }

        public SeriesModality Modality
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Modality"))
                        return _client.Modality;
                    else
                        return default(SeriesModality);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Modality; }
                    );
                return default(SeriesModality);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Modality = value;
            }
        }

        public Study Study
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Study"))
                        return _client.Study;
                    else
                        return default(Study);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Study(_client.Study); }
                    );
                return default(Study);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Study = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UID"))
                        return _client.UID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UID = value;
            }
        }
    }
}