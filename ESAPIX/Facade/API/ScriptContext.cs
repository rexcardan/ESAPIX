#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

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
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructScriptContext(context, user, appName);
                });
            else throw new Exception("There is no VMS Context to create the class");
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
                    return (_client as ExpandoObject).HasProperty("CurrentUser") ? _client.CurrentUser : default(User);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.CurrentUser)) return default(User);
                    return new User(local._client.CurrentUser);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CurrentUser = value;
            }
        }

        public Course Course
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Course") ? _client.Course : default(Course);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Course)) return default(Course);
                    return new Course(local._client.Course);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Course = value;
            }
        }

        public Image Image
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Image") ? _client.Image : default(Image);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Image)) return default(Image);
                    return new Image(local._client.Image);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Image = value;
            }
        }

        public StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StructureSet")
                        ? _client.StructureSet
                        : default(StructureSet);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.StructureSet)) return default(StructureSet);
                    return new StructureSet(local._client.StructureSet);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.StructureSet = value;
            }
        }

        public Patient Patient
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Patient") ? _client.Patient : default(Patient);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Patient)) return default(Patient);
                    return new Patient(local._client.Patient);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Patient = value;
            }
        }

        public PlanSetup PlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("PlanSetup") ? _client.PlanSetup : default(PlanSetup);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.PlanSetup)) return default(PlanSetup);
                    return new PlanSetup(local._client.PlanSetup);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanSetup = value;
            }
        }

        public ExternalPlanSetup ExternalPlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ExternalPlanSetup")
                        ? _client.ExternalPlanSetup
                        : default(ExternalPlanSetup);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ExternalPlanSetup)) return default(ExternalPlanSetup);
                    return new ExternalPlanSetup(local._client.ExternalPlanSetup);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ExternalPlanSetup = value;
            }
        }

        public BrachyPlanSetup BrachyPlanSetup
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("BrachyPlanSetup")
                        ? _client.BrachyPlanSetup
                        : default(BrachyPlanSetup);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.BrachyPlanSetup)) return default(BrachyPlanSetup);
                    return new BrachyPlanSetup(local._client.BrachyPlanSetup);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.BrachyPlanSetup = value;
            }
        }

        public IEnumerable<PlanSetup> PlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlansInScope"))
                        foreach (var item in _client.PlansInScope) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.PlansInScope;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSetup();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.PlansInScope = value;
            }
        }

        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ExternalPlansInScope"))
                        foreach (var item in _client.ExternalPlansInScope) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.ExternalPlansInScope;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new ExternalPlanSetup();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.ExternalPlansInScope = value;
            }
        }

        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BrachyPlansInScope"))
                        foreach (var item in _client.BrachyPlansInScope) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.BrachyPlansInScope;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new BrachyPlanSetup();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.BrachyPlansInScope = value;
            }
        }

        public IEnumerable<PlanSum> PlanSumsInScope
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSumsInScope"))
                        foreach (var item in _client.PlanSumsInScope) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.PlanSumsInScope;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSum();
                        X.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            if (vms != null)
                                facade._client = vms;
                        });
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }
            set
            {
                if (_client is ExpandoObject) _client.PlanSumsInScope = value;
            }
        }

        public string ApplicationName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ApplicationName")
                        ? _client.ApplicationName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ApplicationName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ApplicationName = value;
            }
        }

        public string VersionInfo
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("VersionInfo")
                        ? _client.VersionInfo
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.VersionInfo; });
            }
            set
            {
                if (_client is ExpandoObject) _client.VersionInfo = value;
            }
        }
    }
}