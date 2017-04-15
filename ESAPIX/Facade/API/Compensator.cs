using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Compensator : ESAPIX.Facade.API.ApiDataObject
    {
        public Compensator() { }
        public Compensator(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.AddOnMaterial Material
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.AddOnMaterial(local._client.Material);
            }
        }
        public ESAPIX.Facade.API.Slot Slot
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Slot(local._client.Slot);
            }
        }
        public ESAPIX.Facade.API.Tray Tray
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Tray(local._client.Tray);
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