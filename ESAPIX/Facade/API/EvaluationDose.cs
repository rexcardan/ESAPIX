using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class EvaluationDose : ESAPIX.Facade.API.Dose
    {
        public EvaluationDose() { _client = new ExpandoObject(); }
        public EvaluationDose(dynamic client) { _client = client; }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public void SetVoxels(System.Int32 planeIndex, System.Int32[,] values)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetVoxels(planeIndex, values);
            });

        }
    }
}