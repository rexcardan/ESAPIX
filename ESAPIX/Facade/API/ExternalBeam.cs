using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ExternalBeam : ApiDataObject
    {
        public ExternalBeam()
        {
            _client = new ExpandoObject();
        }

        public ExternalBeam(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double SourceAxisDistance
        {
            get
            {
                if (_client is ExpandoObject) return _client.SourceAxisDistance;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SourceAxisDistance; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SourceAxisDistance = value;
            }
        }

        public string MachineModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.MachineModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MachineModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MachineModel = value;
            }
        }

        public string MachineModelName
        {
            get
            {
                if (_client is ExpandoObject) return _client.MachineModelName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MachineModelName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MachineModelName = value;
            }
        }

        public string MachineScaleDisplayName
        {
            get
            {
                if (_client is ExpandoObject) return _client.MachineScaleDisplayName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.MachineScaleDisplayName;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MachineScaleDisplayName = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}