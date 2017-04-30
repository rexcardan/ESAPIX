#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Registration : ApiDataObject
    {
        public Registration()
        {
            _client = new ExpandoObject();
        }

        public Registration(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CreationDateTime")
                        ? _client.CreationDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public string RegisteredFOR
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("RegisteredFOR")
                        ? _client.RegisteredFOR
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.RegisteredFOR; });
            }
            set
            {
                if (_client is ExpandoObject) _client.RegisteredFOR = value;
            }
        }

        public string SourceFOR
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SourceFOR") ? _client.SourceFOR : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SourceFOR; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SourceFOR = value;
            }
        }

        public double[,] TransformationMatrix
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TransformationMatrix")
                        ? _client.TransformationMatrix
                        : default(double[,]);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double[,]>(sc =>
                {
                    return local._client.TransformationMatrix;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TransformationMatrix = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public Types.VVector InverseTransformPoint(Types.VVector pt)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.VVector(local._client.InverseTransformPoint(pt._client));
            });
            return retVal;
        }

        public Types.VVector TransformPoint(Types.VVector pt)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.VVector(local._client.TransformPoint(pt._client));
            });
            return retVal;
        }
    }
}