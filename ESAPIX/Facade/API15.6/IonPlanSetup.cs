using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class IonPlanSetup : ESAPIX.Facade.API.PlanSetup, System.Xml.Serialization.IXmlSerializable
    {
        public System.Boolean IsPostProcessingNeeded
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsPostProcessingNeeded"))
                    {
                        return _client.IsPostProcessingNeeded;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsPostProcessingNeeded;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsPostProcessingNeeded = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.IsPostProcessingNeeded = (value));
                }
            }
        }

        public ESAPIX.Facade.API.EvaluationDose DoseAsEvaluationDose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DoseAsEvaluationDose"))
                    {
                        return _client.DoseAsEvaluationDose;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.EvaluationDose);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.DoseAsEvaluationDose) != (null))
                        {
                            return new ESAPIX.Facade.API.EvaluationDose(_client.DoseAsEvaluationDose);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.EvaluationDose);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.DoseAsEvaluationDose = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.IonBeam> IonBeams
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("IonBeams"))
                    {
                        foreach (var item in _client.IonBeams)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.IonBeams;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = new ESAPIX.Facade.API.IonBeam();
                        XC.Instance.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                            {
                                facade._client = vms;
                            }
                        }

                        );
                        if (facade._client != null)
                        {
                            yield return facade;
                        }
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IonBeams = value;
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateDose()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateDose());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateDose());
            }
        }

        public ESAPIX.Facade.API.CalculationResult PostProcessAndCalculateDose()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.PostProcessAndCalculateDose());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.PostProcessAndCalculateDose());
            }
        }

        public ESAPIX.Facade.API.CalculationResult CalculateDoseWithoutPostProcessing()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateDoseWithoutPostProcessing());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.CalculationResult(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.CalculationResult)(_client.CalculateDoseWithoutPostProcessing());
            }
        }

        public System.Collections.Generic.IEnumerable<System.String> GetModelsForCalculationType(VMS.TPS.Common.Model.Types.CalculationType calculationType)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetModelsForCalculationType(calculationType));
                    if (fromClient.Equals(default (System.Collections.Generic.IEnumerable<System.String>)))
                    {
                        return default (System.Collections.Generic.IEnumerable<System.String>);
                    }

                    return (System.Collections.Generic.IEnumerable<System.String>)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Collections.Generic.IEnumerable<System.String>)(_client.GetModelsForCalculationType(calculationType));
            }
        }

        public ESAPIX.Facade.API.EvaluationDose CopyEvaluationDose(ESAPIX.Facade.API.Dose existing)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CopyEvaluationDose(existing._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.EvaluationDose(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.EvaluationDose)(_client.CopyEvaluationDose(existing));
            }
        }

        public ESAPIX.Facade.API.EvaluationDose CreateEvaluationDose()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CreateEvaluationDose());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.EvaluationDose(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.EvaluationDose)(_client.CreateEvaluationDose());
            }
        }

        public IonPlanSetup()
        {
            _client = (new ExpandoObject());
        }

        public IonPlanSetup(dynamic client)
        {
            _client = (client);
        }
    }
}