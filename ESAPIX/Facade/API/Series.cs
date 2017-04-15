using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Series : ESAPIX.Facade.API.ApiDataObject
    {
        public Series() { }
        public Series(dynamic client) { _client = client; }
        public System.String FOR
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.FOR; });
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
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceId; });
            }
        }
        public System.String ImagingDeviceManufacturer
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceManufacturer; });
            }
        }
        public System.String ImagingDeviceModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceModel; });
            }
        }
        public System.String ImagingDeviceSerialNo
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ImagingDeviceSerialNo; });
            }
        }
        public ESAPIX.Facade.Types.SeriesModality Modality
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.SeriesModality)local._client.Modality;
            }
        }
        public ESAPIX.Facade.API.Study Study
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Study(local._client.Study);
            }
        }
        public System.String UID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
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