using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Patient : ESAPIX.Facade.API.ApiDataObject
    {
        public Patient() { _client = new ExpandoObject(); }
        public Patient(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public IEnumerable<ESAPIX.Facade.API.Course> Courses
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Courses;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Course();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
            }
        }
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DateOfBirth; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.DateOfBirth; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DateOfBirth = value; }
            }
        }
        public System.String FirstName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FirstName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.FirstName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FirstName = value; }
            }
        }
        public System.Boolean HasModifiedData
        {
            get
            {
                if (_client is ExpandoObject) { return _client.HasModifiedData; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.HasModifiedData; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.HasModifiedData = value; }
            }
        }
        public ESAPIX.Facade.API.Hospital Hospital
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Hospital; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Hospital>((sc) => { if (DefaultHelper.IsDefault(local._client.Hospital)) { return default(ESAPIX.Facade.API.Hospital); } else { return new ESAPIX.Facade.API.Hospital(local._client.Hospital); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Hospital = value; }
            }
        }
        public System.String Id2
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Id2; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id2; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Id2 = value; }
            }
        }
        public System.String LastName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.LastName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.LastName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.LastName = value; }
            }
        }
        public System.String MiddleName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MiddleName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MiddleName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MiddleName = value; }
            }
        }
        public System.String PrimaryOncologistId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PrimaryOncologistId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PrimaryOncologistId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PrimaryOncologistId = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Registration> Registrations
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Registrations;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Registration();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.String Sex
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Sex; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Sex; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Sex = value; }
            }
        }
        public System.String SSN
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SSN; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SSN; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SSN = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.StructureSet> StructureSets
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.StructureSets;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.StructureSet();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Study> Studies
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Studies;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Study();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public ESAPIX.Facade.API.Course AddCourse()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.Course(local._client.AddCourse()); });
            return retVal;

        }
        public ESAPIX.Facade.API.StructureSet AddEmptyPhantom(System.String imageId, ESAPIX.Facade.Types.PatientOrientation orientation, System.Int32 xSizePixel, System.Int32 ySizePixel, System.Double widthMM, System.Double heightMM, System.Int32 nrOfPlanes, System.Double planeSepMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.StructureSet(local._client.AddEmptyPhantom(imageId, (ESAPIX.Facade.Types.PatientOrientation)orientation, xSizePixel, ySizePixel, widthMM, heightMM, nrOfPlanes, planeSepMM)); });
            return retVal;

        }
        public void BeginModifications()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.BeginModifications();
            });

        }
        public System.Boolean CanAddCourse()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanAddCourse(); });
            return retVal;

        }
        public System.Boolean CanAddEmptyPhantom(out System.String errorMessage)
        {
            var errorMessage_OUT = default(System.String);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanAddEmptyPhantom(out errorMessage_OUT); });
            errorMessage = errorMessage_OUT;
            return retVal;

        }
        public System.Boolean CanCopyImageFromOtherPatient(ESAPIX.Facade.API.Study targetStudy, System.String otherPatientId, System.String otherPatientStudyId, System.String otherPatient3DImageId, out System.String errorMessage)
        {
            var errorMessage_OUT = default(System.String);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanCopyImageFromOtherPatient(targetStudy._client, otherPatientId, otherPatientStudyId, otherPatient3DImageId, out errorMessage_OUT); });
            errorMessage = errorMessage_OUT;
            return retVal;

        }
        public System.Boolean CanModifyData()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanModifyData(); });
            return retVal;

        }
        public System.Boolean CanRemoveCourse(ESAPIX.Facade.API.Course course)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanRemoveCourse(course._client); });
            return retVal;

        }
        public System.Boolean CanRemoveEmptyPhantom(ESAPIX.Facade.API.StructureSet structureset, out System.String errorMessage)
        {
            var errorMessage_OUT = default(System.String);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanRemoveEmptyPhantom(structureset._client, out errorMessage_OUT); });
            errorMessage = errorMessage_OUT;
            return retVal;

        }
        public ESAPIX.Facade.API.StructureSet CopyImageFromOtherPatient(System.String otherPatientId, System.String otherPatientStudyId, System.String otherPatient3DImageId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.StructureSet(local._client.CopyImageFromOtherPatient(otherPatientId, otherPatientStudyId, otherPatient3DImageId)); });
            return retVal;

        }
        public ESAPIX.Facade.API.StructureSet CopyImageFromOtherPatient(ESAPIX.Facade.API.Study targetStudy, System.String otherPatientId, System.String otherPatientStudyId, System.String otherPatient3DImageId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.StructureSet(local._client.CopyImageFromOtherPatient(targetStudy._client, otherPatientId, otherPatientStudyId, otherPatient3DImageId)); });
            return retVal;

        }
        public void RemoveCourse(ESAPIX.Facade.API.Course course)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.RemoveCourse(course._client);
            });

        }
        public void RemoveEmptyPhantom(ESAPIX.Facade.API.StructureSet structureset)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.RemoveEmptyPhantom(structureset._client);
            });

        }
    }
}