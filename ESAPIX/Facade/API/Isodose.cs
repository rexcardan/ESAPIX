using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Isodose : ESAPIX.Facade.API.SerializableObject
    {
        public Isodose() { }
        public Isodose(dynamic client) { _client = client; }
        public System.Windows.Media.Color Color
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue Level
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.Level);
            }
        }
        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Media3D.MeshGeometry3D>((sc) => { return local._client.MeshGeometry; });
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