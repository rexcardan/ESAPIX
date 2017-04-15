using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Registration : ESAPIX.Facade.API.ApiDataObject
    {
        public Registration() { _client = new ExpandoObject(); }
        public Registration(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
            }
        }
        public System.String RegisteredFOR
        {
            get
            {
                if (_client is ExpandoObject) { return _client.RegisteredFOR; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.RegisteredFOR; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.RegisteredFOR = value; }
            }
        }
        public System.String SourceFOR
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SourceFOR; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SourceFOR; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SourceFOR = value; }
            }
        }
        public System.Double[,] TransformationMatrix
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TransformationMatrix; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double[,]>((sc) => { return local._client.TransformationMatrix; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TransformationMatrix = value; }
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
        public ESAPIX.Facade.Types.VVector InverseTransformPoint(ESAPIX.Facade.Types.VVector pt)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.InverseTransformPoint(pt._client)); });
            return retVal;

        }
        public ESAPIX.Facade.Types.VVector TransformPoint(ESAPIX.Facade.Types.VVector pt)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.TransformPoint(pt._client)); });
            return retVal;

        }
    }
}