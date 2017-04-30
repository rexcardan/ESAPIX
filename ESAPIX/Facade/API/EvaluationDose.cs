using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class EvaluationDose : Dose
    {
        public EvaluationDose()
        {
            _client = new ExpandoObject();
        }

        public EvaluationDose(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void SetVoxels(int planeIndex, int[,] values)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetVoxels(planeIndex, values); });
        }
    }
}