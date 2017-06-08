#region

using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationEUDObjective : OptimizationObjective, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationEUDObjective()
        {
            _client = new ExpandoObject();
        }

        public OptimizationEUDObjective(dynamic client)
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

        public OptimizationObjectiveOperator Operator
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Operator"))
                        return _client.Operator;
                    else
                        return default(OptimizationObjectiveOperator);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Operator; }
                    );
                return default(OptimizationObjectiveOperator);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Operator = value;
            }
        }

        public double ParameterA
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ParameterA"))
                        return _client.ParameterA;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ParameterA; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ParameterA = value;
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