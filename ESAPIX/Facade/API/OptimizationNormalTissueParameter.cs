using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationNormalTissueParameter : ESAPIX.Facade.API.OptimizationParameter
    {
        public OptimizationNormalTissueParameter() { _client = new ExpandoObject(); }
        public OptimizationNormalTissueParameter(dynamic client) { _client = client; }
        public System.Double DistanceFromTargetBorderInMM
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DistanceFromTargetBorderInMM; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DistanceFromTargetBorderInMM; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DistanceFromTargetBorderInMM = value; }
            }
        }
        public System.Double EndDosePercentage
        {
            get
            {
                if (_client is ExpandoObject) { return _client.EndDosePercentage; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.EndDosePercentage; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.EndDosePercentage = value; }
            }
        }
        public System.Double FallOff
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FallOff; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.FallOff; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FallOff = value; }
            }
        }
        public System.Boolean IsAutomatic
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsAutomatic; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsAutomatic; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsAutomatic = value; }
            }
        }
        public System.Double Priority
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Priority; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Priority; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Priority = value; }
            }
        }
        public System.Double StartDosePercentage
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StartDosePercentage; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StartDosePercentage; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StartDosePercentage = value; }
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