#region

using System.Dynamic;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class EvaluationDose : Dose, System.Xml.Serialization.IXmlSerializable
    {
        public EvaluationDose()
        {
            _client = new ExpandoObject();
        }

        public EvaluationDose(dynamic client)
        {
            _client = client;
        }

        public void SetVoxels(int planeIndex, int[,] values)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetVoxels(planeIndex, values); }
                );
            else
                _client.SetVoxels(planeIndex, values);
        }
    }
}