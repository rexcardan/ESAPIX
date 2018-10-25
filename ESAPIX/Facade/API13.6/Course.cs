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
    public class Course : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Nullable<System.DateTime> CompletedDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CompletedDateTime"))
                    {
                        return _client.CompletedDateTime;
                    }
                    else
                    {
                        return default (System.Nullable<System.DateTime>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CompletedDateTime;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.DateTime>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CompletedDateTime = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Diagnosis> Diagnoses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Diagnoses"))
                    {
                        foreach (var item in _client.Diagnoses)
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
                        var asEnum = (IEnumerable)_client.Diagnoses;
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
                        var facade = new ESAPIX.Facade.API.Diagnosis();
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
                    _client.Diagnoses = value;
            }
        }

        public System.String Intent
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Intent"))
                    {
                        return _client.Intent;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Intent;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Intent = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Patient Patient
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Patient"))
                    {
                        return _client.Patient;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Patient);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Patient) != (null))
                        {
                            return new ESAPIX.Facade.API.Patient(_client.Patient);
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
                    return default (ESAPIX.Facade.API.Patient);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Patient = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanSum> PlanSums
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSums"))
                    {
                        foreach (var item in _client.PlanSums)
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
                        var asEnum = (IEnumerable)_client.PlanSums;
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
                        var facade = new ESAPIX.Facade.API.PlanSum();
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
                    _client.PlanSums = value;
            }
        }

        public System.Nullable<System.DateTime> StartDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StartDateTime"))
                    {
                        return _client.StartDateTime;
                    }
                    else
                    {
                        return default (System.Nullable<System.DateTime>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.StartDateTime;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.DateTime>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StartDateTime = (value);
                }
                else
                {
                }
            }
        }

        public System.String Id
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Id"))
                    {
                        return _client.Id;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Id;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Id = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.Id = (value));
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSetups"))
                    {
                        foreach (var item in _client.PlanSetups)
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
                        var asEnum = (IEnumerable)_client.PlanSetups;
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
                        var facade = new ESAPIX.Facade.API.PlanSetup();
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
                    _client.PlanSetups = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup> ExternalPlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ExternalPlanSetups"))
                    {
                        foreach (var item in _client.ExternalPlanSetups)
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
                        var asEnum = (IEnumerable)_client.ExternalPlanSetups;
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
                        var facade = new ESAPIX.Facade.API.ExternalPlanSetup();
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
                    _client.ExternalPlanSetups = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup> BrachyPlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BrachyPlanSetups"))
                    {
                        foreach (var item in _client.BrachyPlanSetups)
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
                        var asEnum = (IEnumerable)_client.BrachyPlanSetups;
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
                        var facade = new ESAPIX.Facade.API.BrachyPlanSetup();
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
                    _client.BrachyPlanSetups = value;
            }
        }

        public ESAPIX.Facade.API.ExternalPlanSetup AddExternalPlanSetup(ESAPIX.Facade.API.StructureSet structureSet)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddExternalPlanSetup(structureSet._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.ExternalPlanSetup(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.ExternalPlanSetup)(_client.AddExternalPlanSetup(structureSet));
            }
        }

        public ESAPIX.Facade.API.ExternalPlanSetup AddExternalPlanSetupAsVerificationPlan(ESAPIX.Facade.API.StructureSet structureSet, ESAPIX.Facade.API.ExternalPlanSetup verifiedPlan)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddExternalPlanSetupAsVerificationPlan(structureSet._client, verifiedPlan._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.ExternalPlanSetup(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.ExternalPlanSetup)(_client.AddExternalPlanSetupAsVerificationPlan(structureSet, verifiedPlan));
            }
        }

        public System.Boolean CanAddPlanSetup(ESAPIX.Facade.API.StructureSet structureSet)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanAddPlanSetup(structureSet._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanAddPlanSetup(structureSet));
            }
        }

        public System.Boolean CanRemovePlanSetup(ESAPIX.Facade.API.PlanSetup planSetup)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanRemovePlanSetup(planSetup._client));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanRemovePlanSetup(planSetup));
            }
        }

        public void RemovePlanSetup(ESAPIX.Facade.API.PlanSetup planSetup)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemovePlanSetup(planSetup._client);
                }

                );
            }
            else
            {
                _client.RemovePlanSetup(planSetup);
            }
        }

        public Course()
        {
            _client = (new ExpandoObject());
        }

        public Course(dynamic client)
        {
            _client = (client);
        }
    }
}