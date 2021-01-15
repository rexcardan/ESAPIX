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
    public class SerializableObject : System.Xml.Serialization.IXmlSerializable
    {
        internal dynamic _client;

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetSchema());
                    if (fromClient.Equals(default (System.Xml.Schema.XmlSchema)))
                    {
                        return default (System.Xml.Schema.XmlSchema);
                    }

                    return (System.Xml.Schema.XmlSchema)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Xml.Schema.XmlSchema)(_client.GetSchema());
            }
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ReadXml(reader);
                }

                );
            }
            else
            {
                _client.ReadXml(reader);
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.WriteXml(writer);
                }

                );
            }
            else
            {
                _client.WriteXml(writer);
            }
        }

        public SerializableObject()
        {
            _client = (new ExpandoObject());
        }

        public SerializableObject(dynamic client)
        {
            _client = (client);
        }
    }
}