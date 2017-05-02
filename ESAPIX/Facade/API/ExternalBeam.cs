#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion


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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double SourceAxisDistance
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SourceAxisDistance")
                        ? _client.SourceAxisDistance
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MachineModel")
                        ? _client.MachineModel
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MachineModelName")
                        ? _client.MachineModelName
                        : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MachineScaleDisplayName")
                        ? _client.MachineScaleDisplayName
                        : default(string);
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

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}