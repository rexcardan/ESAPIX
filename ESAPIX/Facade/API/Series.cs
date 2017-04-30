using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Series : ESAPIX.Facade.API.ApiDataObject
    {
        public Series() { _client = new ExpandoObject(); }
        public Series(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String FOR
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FOR; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.FOR; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FOR = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Image> Images
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Images;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Image();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.String ImagingDeviceId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ImagingDeviceId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ImagingDeviceId = value; }
            }
        }
        public System.String ImagingDeviceManufacturer
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ImagingDeviceManufacturer; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceManufacturer; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ImagingDeviceManufacturer = value; }
            }
        }
        public System.String ImagingDeviceModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ImagingDeviceModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceModel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ImagingDeviceModel = value; }
            }
        }
        public System.String ImagingDeviceSerialNo
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ImagingDeviceSerialNo; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceSerialNo; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ImagingDeviceSerialNo = value; }
            }
        }
        public ESAPIX.Facade.Types.SeriesModality Modality
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Modality; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.SeriesModality>((sc) => { return (ESAPIX.Facade.Types.SeriesModality)local._client.Modality; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Modality = value; }
            }
        }
        public ESAPIX.Facade.API.Study Study
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Study; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Study>((sc) => { if (DefaultHelper.IsDefault(local._client.Study)) { return default(ESAPIX.Facade.API.Study); } else { return new ESAPIX.Facade.API.Study(local._client.Study); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Study = value; }
            }
        }
        public System.String UID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UID = value; }
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
    }
}