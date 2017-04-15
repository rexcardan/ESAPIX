using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Patient : ESAPIX.Facade.API.ApiDataObject
    {
        public Patient() { }
        public Patient(dynamic client) { _client = client; }
        public IEnumerable<ESAPIX.Facade.API.Course> Courses
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Course>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Courses).Select(s => new ESAPIX.Facade.API.Course(s));
                });
            }
        }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.DateOfBirth; });
            }
        }
        public System.String FirstName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.FirstName; });
            }
        }
        public System.Boolean HasModifiedData
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.HasModifiedData; });
            }
        }
        public ESAPIX.Facade.API.Hospital Hospital
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Hospital(local._client.Hospital);
            }
        }
        public System.String Id2
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id2; });
            }
        }
        public System.String LastName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.LastName; });
            }
        }
        public System.String MiddleName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MiddleName; });
            }
        }
        public System.String PrimaryOncologistId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PrimaryOncologistId; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Registration> Registrations
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Registration>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Registrations).Select(s => new ESAPIX.Facade.API.Registration(s));
                });
            }
        }
        public System.String Sex
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Sex; });
            }
        }
        public System.String SSN
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SSN; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.StructureSet> StructureSets
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.StructureSet>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.StructureSets).Select(s => new ESAPIX.Facade.API.StructureSet(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Study> Studies
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Study>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Studies).Select(s => new ESAPIX.Facade.API.Study(s));
                });
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