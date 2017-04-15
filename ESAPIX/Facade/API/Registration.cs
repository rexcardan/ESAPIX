using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Registration : ESAPIX.Facade.API.ApiDataObject
    {
        public Registration() { }
        public Registration(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public System.String RegisteredFOR
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.RegisteredFOR; });
            }
        }
        public System.String SourceFOR
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SourceFOR; });
            }
        }
        public System.Double[,] TransformationMatrix
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double[,]>((sc) => { return local._client.TransformationMatrix; });
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