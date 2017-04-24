using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationIMRTBeamParameter : ESAPIX.Facade.API.OptimizationParameter
    {
        public OptimizationIMRTBeamParameter() { _client = new ExpandoObject(); }
        public OptimizationIMRTBeamParameter(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.API.Beam Beam
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Beam; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Beam>((sc) => { return new ESAPIX.Facade.API.Beam(local._client.Beam); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Beam = value; }
            }
        }
        public System.String BeamId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.BeamId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.BeamId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.BeamId = value; }
            }
        }
        public System.Boolean Excluded
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Excluded; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.Excluded; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Excluded = value; }
            }
        }
        public System.Boolean FixedJaws
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FixedJaws; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.FixedJaws; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FixedJaws = value; }
            }
        }
        public System.Double SmoothX
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SmoothX; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SmoothX; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SmoothX = value; }
            }
        }
        public System.Double SmoothY
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SmoothY; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SmoothY; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SmoothY = value; }
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