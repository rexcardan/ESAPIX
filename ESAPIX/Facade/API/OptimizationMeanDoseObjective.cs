#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationMeanDoseObjective : OptimizationObjective, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationMeanDoseObjective()
        {
            _client = new ExpandoObject();
        }

        public OptimizationMeanDoseObjective(dynamic client)
        {
            _client = client;
        }

        public DoseValue Dose
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Dose"))
                        return _client.Dose;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Dose; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Dose = value;
            }
        }

        public double Priority
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Priority"))
                        return _client.Priority;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Priority; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Priority = value;
                }
            }
        }
    }
}