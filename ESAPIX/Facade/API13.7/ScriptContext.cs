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
    public class ScriptContext
    {
        internal dynamic _client;
        public bool IsLive
        {
            get
            {
                return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject);
            }
        }

        public ESAPIX.Facade.API.User CurrentUser
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CurrentUser"))
                    {
                        return _client.CurrentUser;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.User);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.CurrentUser) != (null))
                        {
                            return new ESAPIX.Facade.API.User(_client.CurrentUser);
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
                    return default (ESAPIX.Facade.API.User);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CurrentUser = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Course"))
                    {
                        return _client.Course;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Course);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Course) != (null))
                        {
                            return new ESAPIX.Facade.API.Course(_client.Course);
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
                    return default (ESAPIX.Facade.API.Course);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Course = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Image Image
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Image"))
                    {
                        return _client.Image;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Image);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Image) != (null))
                        {
                            return new ESAPIX.Facade.API.Image(_client.Image);
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
                    return default (ESAPIX.Facade.API.Image);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Image = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("StructureSet"))
                    {
                        return _client.StructureSet;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.StructureSet);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.StructureSet) != (null))
                        {
                            return new ESAPIX.Facade.API.StructureSet(_client.StructureSet);
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
                    return default (ESAPIX.Facade.API.StructureSet);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.StructureSet = (value);
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

        public ESAPIX.Facade.API.PlanSetup PlanSetup
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PlanSetup"))
                    {
                        return _client.PlanSetup;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.PlanSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.PlanSetup) != (null))
                        {
                            return new ESAPIX.Facade.API.PlanSetup(_client.PlanSetup);
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
                    return default (ESAPIX.Facade.API.PlanSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PlanSetup = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.ExternalPlanSetup ExternalPlanSetup
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ExternalPlanSetup"))
                    {
                        return _client.ExternalPlanSetup;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.ExternalPlanSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.ExternalPlanSetup) != (null))
                        {
                            return new ESAPIX.Facade.API.ExternalPlanSetup(_client.ExternalPlanSetup);
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
                    return default (ESAPIX.Facade.API.ExternalPlanSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ExternalPlanSetup = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.BrachyPlanSetup BrachyPlanSetup
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("BrachyPlanSetup"))
                    {
                        return _client.BrachyPlanSetup;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.BrachyPlanSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.BrachyPlanSetup) != (null))
                        {
                            return new ESAPIX.Facade.API.BrachyPlanSetup(_client.BrachyPlanSetup);
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
                    return default (ESAPIX.Facade.API.BrachyPlanSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.BrachyPlanSetup = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.IonPlanSetup IonPlanSetup
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IonPlanSetup"))
                    {
                        return _client.IonPlanSetup;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.IonPlanSetup);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.IonPlanSetup) != (null))
                        {
                            return new ESAPIX.Facade.API.IonPlanSetup(_client.IonPlanSetup);
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
                    return default (ESAPIX.Facade.API.IonPlanSetup);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IonPlanSetup = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlansInScope"))
                    {
                        foreach (var item in _client.PlansInScope)
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
                        var asEnum = (IEnumerable)_client.PlansInScope;
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
                    _client.PlansInScope = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup> ExternalPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ExternalPlansInScope"))
                    {
                        foreach (var item in _client.ExternalPlansInScope)
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
                        var asEnum = (IEnumerable)_client.ExternalPlansInScope;
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
                    _client.ExternalPlansInScope = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup> BrachyPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BrachyPlansInScope"))
                    {
                        foreach (var item in _client.BrachyPlansInScope)
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
                        var asEnum = (IEnumerable)_client.BrachyPlansInScope;
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
                    _client.BrachyPlansInScope = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.IonPlanSetup> IonPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("IonPlansInScope"))
                    {
                        foreach (var item in _client.IonPlansInScope)
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
                        var asEnum = (IEnumerable)_client.IonPlansInScope;
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
                        var facade = new ESAPIX.Facade.API.IonPlanSetup();
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
                    _client.IonPlansInScope = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.PlanSum> PlanSumsInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSumsInScope"))
                    {
                        foreach (var item in _client.PlanSumsInScope)
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
                        var asEnum = (IEnumerable)_client.PlanSumsInScope;
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
                    _client.PlanSumsInScope = value;
            }
        }

        public System.String ApplicationName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ApplicationName"))
                    {
                        return _client.ApplicationName;
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
                        return _client.ApplicationName;
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
                    _client.ApplicationName = (value);
                }
                else
                {
                }
            }
        }

        public System.String VersionInfo
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("VersionInfo"))
                    {
                        return _client.VersionInfo;
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
                        return _client.VersionInfo;
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
                    _client.VersionInfo = (value);
                }
                else
                {
                }
            }
        }

        public ScriptContext()
        {
            _client = (new ExpandoObject());
        }

        public ScriptContext(dynamic client)
        {
            _client = (client);
        }

        public ScriptContext(System.Object context, System.Object user, System.String appName)
        {
            if ((XC.Instance) != (null))
            {
                _client = (VMSConstructor.ConstructScriptContextFunc0(context, user, appName));
            }
            else
            {
                throw new Exception("There is no VMS Context to create the class");
            }
        }
    }
}