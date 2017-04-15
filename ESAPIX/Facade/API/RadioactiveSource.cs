using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class RadioactiveSource : ESAPIX.Facade.API.ApiDataObject
    {
        public RadioactiveSource() { }
        public RadioactiveSource(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CalibrationDate
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CalibrationDate; });
            }
        }
        public System.Boolean NominalActivity
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.NominalActivity; });
            }
        }
        public ESAPIX.Facade.API.RadioactiveSourceModel RadioactiveSourceModel
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.RadioactiveSourceModel(local._client.RadioactiveSourceModel);
            }
        }
        public System.String SerialNumber
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SerialNumber; });
            }
        }
        public System.Double Strength
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Strength; });
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