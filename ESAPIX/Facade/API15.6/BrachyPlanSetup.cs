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
    public class BrachyPlanSetup : ESAPIX.Facade.API.PlanSetup, System.Xml.Serialization.IXmlSerializable
    {
        public System.String ApplicationSetupType
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ApplicationSetupType"))
                    {
                        return _client.ApplicationSetupType;
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
                        return _client.ApplicationSetupType;
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
                    _client.ApplicationSetupType = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Catheter> Catheters
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Catheters"))
                    {
                        foreach (var item in _client.Catheters)
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
                        var asEnum = (IEnumerable)_client.Catheters;
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
                        var facade = new ESAPIX.Facade.API.Catheter();
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
                    _client.Catheters = value;
            }
        }

        public System.Nullable<System.Int32> NumberOfPdrPulses
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NumberOfPdrPulses"))
                    {
                        return _client.NumberOfPdrPulses;
                    }
                    else
                    {
                        return default (System.Nullable<System.Int32>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.NumberOfPdrPulses;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.Int32>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.NumberOfPdrPulses = (value);
                }
                else
                {
                }
            }
        }

        public System.Nullable<System.Double> PdrPulseInterval
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PdrPulseInterval"))
                    {
                        return _client.PdrPulseInterval;
                    }
                    else
                    {
                        return default (System.Nullable<System.Double>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PdrPulseInterval;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.Double>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PdrPulseInterval = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.SeedCollection> SeedCollections
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SeedCollections"))
                    {
                        foreach (var item in _client.SeedCollections)
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
                        var asEnum = (IEnumerable)_client.SeedCollections;
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
                        var facade = new ESAPIX.Facade.API.SeedCollection();
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
                    _client.SeedCollections = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.BrachySolidApplicator> SolidApplicators
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SolidApplicators"))
                    {
                        foreach (var item in _client.SolidApplicators)
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
                        var asEnum = (IEnumerable)_client.SolidApplicators;
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
                        var facade = new ESAPIX.Facade.API.BrachySolidApplicator();
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
                    _client.SolidApplicators = value;
            }
        }

        public System.Nullable<System.DateTime> TreatmentDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentDateTime"))
                    {
                        return _client.TreatmentDateTime;
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
                        return _client.TreatmentDateTime;
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
                    _client.TreatmentDateTime = (value);
                }
                else
                {
                }
            }
        }

        public System.String TreatmentTechnique
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("TreatmentTechnique"))
                    {
                        return _client.TreatmentTechnique;
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
                        return _client.TreatmentTechnique;
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
                    _client.TreatmentTechnique = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.DoseProfile CalculateAccurateTG43DoseProfile(VMS.TPS.Common.Model.Types.VVector start, VMS.TPS.Common.Model.Types.VVector stop, System.Double[] preallocatedBuffer)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CalculateAccurateTG43DoseProfile(start, stop, preallocatedBuffer));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.DoseProfile)))
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseProfile);
                    }

                    return (VMS.TPS.Common.Model.Types.DoseProfile)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.DoseProfile)(_client.CalculateAccurateTG43DoseProfile(start, stop, preallocatedBuffer));
            }
        }

        public BrachyPlanSetup()
        {
            _client = (new ExpandoObject());
        }

        public BrachyPlanSetup(dynamic client)
        {
            _client = (client);
        }
    }
}