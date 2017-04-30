using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Patient : ApiDataObject
    {
        public Patient()
        {
            _client = new ExpandoObject();
        }

        public Patient(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public IEnumerable<Course> Courses
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Courses;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Course();
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

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) return _client.CreationDateTime;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                if (_client is ExpandoObject) return _client.DateOfBirth;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.DateOfBirth; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DateOfBirth = value;
            }
        }

        public string FirstName
        {
            get
            {
                if (_client is ExpandoObject) return _client.FirstName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.FirstName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FirstName = value;
            }
        }

        public bool HasModifiedData
        {
            get
            {
                if (_client is ExpandoObject) return _client.HasModifiedData;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.HasModifiedData; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HasModifiedData = value;
            }
        }

        public Hospital Hospital
        {
            get
            {
                if (_client is ExpandoObject) return _client.Hospital;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Hospital)) return default(Hospital);
                    return new Hospital(local._client.Hospital);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Hospital = value;
            }
        }

        public string Id2
        {
            get
            {
                if (_client is ExpandoObject) return _client.Id2;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id2; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id2 = value;
            }
        }

        public string LastName
        {
            get
            {
                if (_client is ExpandoObject) return _client.LastName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.LastName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.LastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                if (_client is ExpandoObject) return _client.MiddleName;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MiddleName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MiddleName = value;
            }
        }

        public string PrimaryOncologistId
        {
            get
            {
                if (_client is ExpandoObject) return _client.PrimaryOncologistId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PrimaryOncologistId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PrimaryOncologistId = value;
            }
        }

        public IEnumerable<Registration> Registrations
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Registrations;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Registration();
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

        public string Sex
        {
            get
            {
                if (_client is ExpandoObject) return _client.Sex;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Sex; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Sex = value;
            }
        }

        public string SSN
        {
            get
            {
                if (_client is ExpandoObject) return _client.SSN;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SSN; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SSN = value;
            }
        }

        public IEnumerable<StructureSet> StructureSets
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.StructureSets;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new StructureSet();
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

        public IEnumerable<Study> Studies
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Studies;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Study();
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

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public Course AddCourse()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return new Course(local._client.AddCourse()); });
            return retVal;
        }

        public StructureSet AddEmptyPhantom(string imageId, PatientOrientation orientation, int xSizePixel,
            int ySizePixel, double widthMM, double heightMM, int nrOfPlanes, double planeSepMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new StructureSet(local._client.AddEmptyPhantom(imageId, orientation, xSizePixel, ySizePixel,
                    widthMM, heightMM, nrOfPlanes, planeSepMM));
            });
            return retVal;
        }

        public void BeginModifications()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.BeginModifications(); });
        }

        public bool CanAddCourse()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.CanAddCourse(); });
            return retVal;
        }

        public bool CanAddEmptyPhantom(out string errorMessage)
        {
            var errorMessage_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanAddEmptyPhantom(out errorMessage_OUT);
            });
            errorMessage = errorMessage_OUT;
            return retVal;
        }

        public bool CanCopyImageFromOtherPatient(Study targetStudy, string otherPatientId, string otherPatientStudyId,
            string otherPatient3DImageId, out string errorMessage)
        {
            var errorMessage_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanCopyImageFromOtherPatient(targetStudy._client, otherPatientId,
                    otherPatientStudyId, otherPatient3DImageId, out errorMessage_OUT);
            });
            errorMessage = errorMessage_OUT;
            return retVal;
        }

        public bool CanModifyData()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.CanModifyData(); });
            return retVal;
        }

        public bool CanRemoveCourse(Course course)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanRemoveCourse(course._client);
            });
            return retVal;
        }

        public bool CanRemoveEmptyPhantom(StructureSet structureset, out string errorMessage)
        {
            var errorMessage_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanRemoveEmptyPhantom(structureset._client, out errorMessage_OUT);
            });
            errorMessage = errorMessage_OUT;
            return retVal;
        }

        public StructureSet CopyImageFromOtherPatient(string otherPatientId, string otherPatientStudyId,
            string otherPatient3DImageId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new StructureSet(local._client.CopyImageFromOtherPatient(otherPatientId, otherPatientStudyId,
                    otherPatient3DImageId));
            });
            return retVal;
        }

        public StructureSet CopyImageFromOtherPatient(Study targetStudy, string otherPatientId,
            string otherPatientStudyId, string otherPatient3DImageId)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new StructureSet(local._client.CopyImageFromOtherPatient(targetStudy._client, otherPatientId,
                    otherPatientStudyId, otherPatient3DImageId));
            });
            return retVal;
        }

        public void RemoveCourse(Course course)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.RemoveCourse(course._client); });
        }

        public void RemoveEmptyPhantom(StructureSet structureset)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.RemoveEmptyPhantom(structureset._client); });
        }
    }
}