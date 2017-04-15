using System;
using System.Collections.Generic;
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
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Image>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Images).Select(s => new ESAPIX.Facade.API.Image(s));
                });
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