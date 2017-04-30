#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public double DwellTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DwellTime") ? _client.DwellTime : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("RadioactiveSource")
                        ? _client.RadioactiveSource
                        : default(RadioactiveSource);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Transform") ? _client.Transform : default(double[,]);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double[,]>(sc => { return local._client.Transform; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Transform = value;
            }
        }

        public Types.VVector Translation
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Translation")
                        ? _client.Translation
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Translation)) return default(Types.VVector);
                    return new Types.VVector(local._client.Translation);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Translation = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}