using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class RadioactiveSource : ESAPIX.Facade.API.ApiDataObject
    {
        public RadioactiveSource() { _client = new ExpandoObject(); }
        public RadioactiveSource(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Nullable<System.DateTime> CalibrationDate
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CalibrationDate; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CalibrationDate; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CalibrationDate = value; }
            }
        }
        public System.Boolean NominalActivity
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NominalActivity; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.NominalActivity; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NominalActivity = value; }
            }
        }
        public ESAPIX.Facade.API.RadioactiveSourceModel RadioactiveSourceModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.RadioactiveSourceModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.RadioactiveSourceModel>((sc) => { if (DefaultHelper.IsDefault(local._client.RadioactiveSourceModel)) { return default(ESAPIX.Facade.API.RadioactiveSourceModel); } else { return new ESAPIX.Facade.API.RadioactiveSourceModel(local._client.RadioactiveSourceModel); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.RadioactiveSourceModel = value; }
            }
        }
        public System.String SerialNumber
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SerialNumber; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SerialNumber; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SerialNumber = value; }
            }
        }
        public System.Double Strength
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Strength; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Strength; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Strength = value; }
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