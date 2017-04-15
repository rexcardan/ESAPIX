using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Isodose : ESAPIX.Facade.API.SerializableObject
    {
        public Isodose() { _client = new ExpandoObject(); }
        public Isodose(dynamic client) { _client = client; }
        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Color; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Color = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue Level
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Level; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.Level); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Level = value; }
            }
        }
        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MeshGeometry; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Media3D.MeshGeometry3D>((sc) => { return local._client.MeshGeometry; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MeshGeometry = value; }
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