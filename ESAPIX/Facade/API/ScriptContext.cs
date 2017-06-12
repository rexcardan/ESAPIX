#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ScriptContext
    {
        internal dynamic _client;

        public ScriptContext()
        {
            _client = new ExpandoObject();
        }

        public ScriptContext(dynamic client)
        {
            _client = client;
        }

        public ScriptContext(object context, object user, string appName)
        {
            if (XC.Instance.CurrentContext != null)
                _client = VMSConstructor.ConstructScriptContextFunc0(context, user, appName);
            else
                throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public User CurrentUser
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CurrentUser"))
                        return _client.CurrentUser;
                    else
                        return default(User);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.CurrentUser != null)
                                return new User(_client.CurrentUser);
                            return null;
                        }
                    );
                return default(User);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CurrentUser = value;
            }
        }

        public Course Course
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Course"))
                        return _client.Course;
                    else
                        return default(Course);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Course != null)
                                return new Course(_client.Course);
                            return null;
                        }
                    );
                return default(Course);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Course = value;
            }
        }

        public Image Image
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Image"))
                        return _client.Image;
                    else
                        return default(Image);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Image != null)
                                return new Image(_client.Image);
                            return null;
                        }
                    );
                return default(Image);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Image = value;
            }
        }

        public StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StructureSet"))
                        return _client.StructureSet;
                    else
                        return default(StructureSet);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.StructureSet != null)
                                return new StructureSet(_client.StructureSet);
                            return null;
                        }
                    );
                return default(StructureSet);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureSet = value;
            }
        }

        public Patient Patient
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Patient"))
                        return _client.Patient;
                    else
                        return default(Patient);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Patient != null)
                                return new Patient(_client.Patient);
                            return null;
                        }
                    );
                return default(Patient);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Patient = value;
            }
        }

        public PlanSetup PlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PlanSetup"))
                        return _client.PlanSetup;
                    else
                        return default(PlanSetup);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.PlanSetup != null)
                                return new PlanSetup(_client.PlanSetup);
                            return null;
                        }
                    );
                return default(PlanSetup);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanSetup = value;
            }
        }

        public ExternalPlanSetup ExternalPlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ExternalPlanSetup"))
                        return _client.ExternalPlanSetup;
                    else
                        return default(ExternalPlanSetup);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.ExternalPlanSetup != null)
                                return new ExternalPlanSetup(_client.ExternalPlanSetup);
                            return null;
                        }
                    );
                return default(ExternalPlanSetup);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ExternalPlanSetup = value;
            }
        }

        public BrachyPlanSetup BrachyPlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("BrachyPlanSetup"))
                        return _client.BrachyPlanSetup;
                    else
                        return default(BrachyPlanSetup);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.BrachyPlanSetup != null)
                                return new BrachyPlanSetup(_client.BrachyPlanSetup);
                            return null;
                        }
                    );
                return default(BrachyPlanSetup);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.BrachyPlanSetup = value;
            }
        }

        public IEnumerable<PlanSetup> PlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlansInScope"))
                        foreach (var item in _client.PlansInScope)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PlansInScope;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSetup();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlansInScope = value;
            }
        }

        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ExternalPlansInScope"))
                        foreach (var item in _client.ExternalPlansInScope)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.ExternalPlansInScope;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new ExternalPlanSetup();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ExternalPlansInScope = value;
            }
        }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BrachyPlansInScope"))
                        foreach (var item in _client.BrachyPlansInScope)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.BrachyPlansInScope;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new BrachyPlanSetup();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.BrachyPlansInScope = value;
            }
        }

        public IEnumerable<PlanSum> PlanSumsInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSumsInScope"))
                        foreach (var item in _client.PlanSumsInScope)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PlanSumsInScope;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSum();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PlanSumsInScope = value;
            }
        }

        public string ApplicationName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ApplicationName"))
                        return _client.ApplicationName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ApplicationName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ApplicationName = value;
            }
        }

        public string VersionInfo
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("VersionInfo"))
                        return _client.VersionInfo;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.VersionInfo; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.VersionInfo = value;
            }
        }
    }
}