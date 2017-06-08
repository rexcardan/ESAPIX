#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Patient : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Patient()
        {
            _client = new ExpandoObject();
        }

        public Patient(dynamic client)
        {
            _client = client;
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Courses"))
                        foreach (var item in _client.Courses)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Courses;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Course();
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
                    _client.Courses = value;
            }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationDateTime"))
                        return _client.CreationDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationDateTime = value;
            }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DateOfBirth"))
                        return _client.DateOfBirth;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DateOfBirth; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DateOfBirth = value;
            }
        }

        public string FirstName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("FirstName"))
                        return _client.FirstName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.FirstName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.FirstName = value;
            }
        }

        public bool HasModifiedData
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("HasModifiedData"))
                        return _client.HasModifiedData;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.HasModifiedData; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.HasModifiedData = value;
            }
        }

        public Hospital Hospital
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Hospital"))
                        return _client.Hospital;
                    else
                        return default(Hospital);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Hospital(_client.Hospital); }
                    );
                return default(Hospital);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Hospital = value;
            }
        }

        public string Id2
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Id2"))
                        return _client.Id2;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Id2; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Id2 = value;
            }
        }

        public string LastName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("LastName"))
                        return _client.LastName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.LastName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.LastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MiddleName"))
                        return _client.MiddleName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MiddleName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MiddleName = value;
            }
        }

        public string PrimaryOncologistId
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PrimaryOncologistId"))
                        return _client.PrimaryOncologistId;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PrimaryOncologistId; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PrimaryOncologistId = value;
            }
        }

        public IEnumerable<Registration> Registrations
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Registrations"))
                        foreach (var item in _client.Registrations)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Registrations;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Registration();
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
                    _client.Registrations = value;
            }
        }

        public string Sex
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Sex"))
                        return _client.Sex;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Sex; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Sex = value;
            }
        }

        public string SSN
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SSN"))
                        return _client.SSN;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SSN; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SSN = value;
            }
        }

        public IEnumerable<StructureSet> StructureSets
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureSets"))
                        foreach (var item in _client.StructureSets)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.StructureSets;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new StructureSet();
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
                    _client.StructureSets = value;
            }
        }

        public IEnumerable<Study> Studies
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Studies"))
                        foreach (var item in _client.Studies)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Studies;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Study();
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
                    _client.Studies = value;
            }
        }

        public Course AddCourse()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return new Course(_client.AddCourse()); }
                );
                return vmsResult;
            }
            return _client.AddCourse();
        }

        public StructureSet AddEmptyPhantom(string imageId, PatientOrientation orientation, int xSizePixel,
            int ySizePixel, double widthMM, double heightMM, int nrOfPlanes, double planeSepMM)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new StructureSet(_client.AddEmptyPhantom(imageId, orientation, xSizePixel, ySizePixel,
                            widthMM, heightMM, nrOfPlanes, planeSepMM));
                    }
                );
                return vmsResult;
            }
            return _client.AddEmptyPhantom(imageId, orientation, xSizePixel, ySizePixel, widthMM, heightMM, nrOfPlanes,
                planeSepMM);
        }

        public void BeginModifications()
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.BeginModifications(); }
                );
            else
                _client.BeginModifications();
        }

        public bool CanAddCourse()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.CanAddCourse(); }
                );
                return vmsResult;
            }
            return (bool) _client.CanAddCourse();
        }

        public bool CanAddEmptyPhantom(out string errorMessage)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var errorMessage_OUT = default(string);
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanAddEmptyPhantom(out errorMessage_OUT); }
                );
                errorMessage = errorMessage_OUT;
                return vmsResult;
            }
            return (bool) _client.CanAddEmptyPhantom(out errorMessage);
        }

        public bool CanCopyImageFromOtherPatient(Study targetStudy, string otherPatientId, string otherPatientStudyId,
            string otherPatient3DImageId, out string errorMessage)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var errorMessage_OUT = default(string);
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.CanCopyImageFromOtherPatient(targetStudy._client, otherPatientId,
                            otherPatientStudyId, otherPatient3DImageId, out errorMessage_OUT);
                    }
                );
                errorMessage = errorMessage_OUT;
                return vmsResult;
            }
            return (bool) _client.CanCopyImageFromOtherPatient(targetStudy, otherPatientId, otherPatientStudyId,
                otherPatient3DImageId, out errorMessage);
        }

        public bool CanModifyData()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.CanModifyData(); }
                );
                return vmsResult;
            }
            return (bool) _client.CanModifyData();
        }

        public bool CanRemoveCourse(Course course)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanRemoveCourse(course._client); }
                );
                return vmsResult;
            }
            return (bool) _client.CanRemoveCourse(course);
        }

        public bool CanRemoveEmptyPhantom(StructureSet structureset, out string errorMessage)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var errorMessage_OUT = default(string);
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.CanRemoveEmptyPhantom(structureset._client, out errorMessage_OUT);
                    }
                );
                errorMessage = errorMessage_OUT;
                return vmsResult;
            }
            return (bool) _client.CanRemoveEmptyPhantom(structureset, out errorMessage);
        }

        public StructureSet CopyImageFromOtherPatient(string otherPatientId, string otherPatientStudyId,
            string otherPatient3DImageId)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new StructureSet(_client.CopyImageFromOtherPatient(otherPatientId, otherPatientStudyId,
                            otherPatient3DImageId));
                    }
                );
                return vmsResult;
            }
            return _client.CopyImageFromOtherPatient(otherPatientId, otherPatientStudyId, otherPatient3DImageId);
        }

        public StructureSet CopyImageFromOtherPatient(Study targetStudy, string otherPatientId,
            string otherPatientStudyId, string otherPatient3DImageId)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new StructureSet(_client.CopyImageFromOtherPatient(targetStudy, otherPatientId,
                            otherPatientStudyId, otherPatient3DImageId));
                    }
                );
                return vmsResult;
            }
            return _client.CopyImageFromOtherPatient(targetStudy, otherPatientId, otherPatientStudyId,
                otherPatient3DImageId);
        }

        public void RemoveCourse(Course course)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemoveCourse(course._client); }
                );
            else
                _client.RemoveCourse(course);
        }

        public void RemoveEmptyPhantom(StructureSet structureset)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemoveEmptyPhantom(structureset._client); }
                );
            else
                _client.RemoveEmptyPhantom(structureset);
        }
    }
}