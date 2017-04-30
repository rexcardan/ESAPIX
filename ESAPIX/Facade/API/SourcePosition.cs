using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SourcePosition : ApiDataObject
    {
        public SourcePosition()
        {
            _client = new ExpandoObject();
        }

        public SourcePosition(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double DwellTime
        {
            get
            {
                if (_client is ExpandoObject) return _client.DwellTime;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.DwellTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DwellTime = value;
            }
        }

        public RadioactiveSource RadioactiveSource
        {
            get
            {
                if (_client is ExpandoObject) return _client.RadioactiveSource;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.RadioactiveSource)) return default(RadioactiveSource);
                    return new RadioactiveSource(local._client.RadioactiveSource);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.RadioactiveSource = value;
            }
        }

        public double[,] Transform
        {
            get
            {
                if (_client is ExpandoObject) return _client.Transform;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double[,]>(sc => { return local._client.Transform; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Transform = value;
            }
        }

        public VVector Translation
        {
            get
            {
                if (_client is ExpandoObject) return _client.Translation;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Translation)) return default(VVector);
                    return new VVector(local._client.Translation);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Translation = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}