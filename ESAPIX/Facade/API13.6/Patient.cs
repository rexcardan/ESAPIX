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
    public class Patient : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public IEnumerable<ESAPIX.Facade.API.Course> Courses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Courses"))
                    {
                        foreach (var item in _client.Courses)
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
                        var asEnum = (IEnumerable)_client.Courses;
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
                        var facade = new ESAPIX.Facade.API.Course();
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
                    _client.Courses = value;
            }
        }

        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CreationDateTime"))
                    {
                        return _client.CreationDateTime;
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
                        return _client.CreationDateTime;
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
                    _client.CreationDateTime = (value);
                }
                else
                {
                }
            }
        }

        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DateOfBirth"))
                    {
                        return _client.DateOfBirth;
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
                        return _client.DateOfBirth;
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
                    _client.DateOfBirth = (value);
                }
                else
                {
                }
            }
        }

        public System.String FirstName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FirstName"))
                    {
                        return _client.FirstName;
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
                        return _client.FirstName;
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
                    _client.FirstName = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean HasModifiedData
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("HasModifiedData"))
                    {
                        return _client.HasModifiedData;
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
                        return _client.HasModifiedData;
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
                    _client.HasModifiedData = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Hospital Hospital
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Hospital"))
                    {
                        return _client.Hospital;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Hospital);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Hospital) != (null))
                        {
                            return new ESAPIX.Facade.API.Hospital(_client.Hospital);
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
                    return default (ESAPIX.Facade.API.Hospital);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Hospital = (value);
                }
                else
                {
                }
            }
        }

        public System.String Id2
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Id2"))
                    {
                        return _client.Id2;
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
                        return _client.Id2;
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
                    _client.Id2 = (value);
                }
                else
                {
                }
            }
        }

        public System.String LastName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("LastName"))
                    {
                        return _client.LastName;
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
                        return _client.LastName;
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
                    _client.LastName = (value);
                }
                else
                {
                }
            }
        }

        public System.String MiddleName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MiddleName"))
                    {
                        return _client.MiddleName;
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
                        return _client.MiddleName;
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
                    _client.MiddleName = (value);
                }
                else
                {
                }
            }
        }

        public System.String PrimaryOncologistId
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PrimaryOncologistId"))
                    {
                        return _client.PrimaryOncologistId;
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
                        return _client.PrimaryOncologistId;
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
                    _client.PrimaryOncologistId = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Registration> Registrations
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Registrations"))
                    {
                        foreach (var item in _client.Registrations)
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
                        var asEnum = (IEnumerable)_client.Registrations;
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
                        var facade = new ESAPIX.Facade.API.Registration();
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
                    _client.Registrations = value;
            }
        }

        public System.String Sex
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Sex"))
                    {
                        return _client.Sex;
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
                        return _client.Sex;
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
                    _client.Sex = (value);
                }
                else
                {
                }
            }
        }

        public System.String SSN
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SSN"))
                    {
                        return _client.SSN;
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
                        return _client.SSN;
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
                    _client.SSN = (value);
                }
                else
                {
                }
            }
        }

        public IEnumerable<ESAPIX.Facade.API.StructureSet> StructureSets
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureSets"))
                    {
                        foreach (var item in _client.StructureSets)
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
                        var asEnum = (IEnumerable)_client.StructureSets;
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
                        var facade = new ESAPIX.Facade.API.StructureSet();
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
                    _client.StructureSets = value;
            }
        }

        public IEnumerable<ESAPIX.Facade.API.Study> Studies
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Studies"))
                    {
                        foreach (var item in _client.Studies)
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
                        var asEnum = (IEnumerable)_client.Studies;
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
                        var facade = new ESAPIX.Facade.API.Study();
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
                    _client.Studies = value;
            }
        }

        public ESAPIX.Facade.API.Course AddCourse()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddCourse());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.Course(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.Course)(_client.AddCourse());
            }
        }

        public ESAPIX.Facade.API.StructureSet AddEmptyPhantom(System.String imageId, VMS.TPS.Common.Model.Types.PatientOrientation orientation, System.Int32 xSizePixel, System.Int32 ySizePixel, System.Double widthMM, System.Double heightMM, System.Int32 nrOfPlanes, System.Double planeSepMM)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AddEmptyPhantom(imageId, orientation, xSizePixel, ySizePixel, widthMM, heightMM, nrOfPlanes, planeSepMM));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.StructureSet(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.StructureSet)(_client.AddEmptyPhantom(imageId, orientation, xSizePixel, ySizePixel, widthMM, heightMM, nrOfPlanes, planeSepMM));
            }
        }

        public void BeginModifications()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.BeginModifications();
                }

                );
            }
            else
            {
                _client.BeginModifications();
            }
        }

        public System.Boolean CanAddCourse()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanAddCourse());
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
                return (System.Boolean)(_client.CanAddCourse());
            }
        }

        public System.Boolean CanAddEmptyPhantom(out System.String errorMessage)
        {
            if ((XC.Instance) != (null))
            {
                var errorMessage_OUT = (default (System.String));
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanAddEmptyPhantom(out errorMessage_OUT));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                errorMessage = (errorMessage_OUT);
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanAddEmptyPhantom(out errorMessage));
            }
        }

        public System.Boolean CanCopyImageFromOtherPatient(ESAPIX.Facade.API.Study targetStudy, System.String otherPatientId, System.String otherPatientStudyId, System.String otherPatient3DImageId, out System.String errorMessage)
        {
            if ((XC.Instance) != (null))
            {
                var errorMessage_OUT = (default (System.String));
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanCopyImageFromOtherPatient(targetStudy._client, otherPatientId, otherPatientStudyId, otherPatient3DImageId, out errorMessage_OUT));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                errorMessage = (errorMessage_OUT);
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanCopyImageFromOtherPatient(targetStudy, otherPatientId, otherPatientStudyId, otherPatient3DImageId, out errorMessage));
            }
        }

        public System.Boolean CanModifyData()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanModifyData());
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
                return (System.Boolean)(_client.CanModifyData());
            }
        }

        public System.Boolean CanRemoveCourse(ESAPIX.Facade.API.Course course)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanRemoveCourse(course._client));
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
                return (System.Boolean)(_client.CanRemoveCourse(course));
            }
        }

        public System.Boolean CanRemoveEmptyPhantom(ESAPIX.Facade.API.StructureSet structureset, out System.String errorMessage)
        {
            if ((XC.Instance) != (null))
            {
                var errorMessage_OUT = (default (System.String));
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanRemoveEmptyPhantom(structureset._client, out errorMessage_OUT));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                errorMessage = (errorMessage_OUT);
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanRemoveEmptyPhantom(structureset, out errorMessage));
            }
        }

        public ESAPIX.Facade.API.StructureSet CopyImageFromOtherPatient(System.String otherPatientId, System.String otherPatientStudyId, System.String otherPatient3DImageId)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CopyImageFromOtherPatient(otherPatientId, otherPatientStudyId, otherPatient3DImageId));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.StructureSet(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.StructureSet)(_client.CopyImageFromOtherPatient(otherPatientId, otherPatientStudyId, otherPatient3DImageId));
            }
        }

        public ESAPIX.Facade.API.StructureSet CopyImageFromOtherPatient(ESAPIX.Facade.API.Study targetStudy, System.String otherPatientId, System.String otherPatientStudyId, System.String otherPatient3DImageId)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CopyImageFromOtherPatient(targetStudy._client, otherPatientId, otherPatientStudyId, otherPatient3DImageId));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.StructureSet(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.StructureSet)(_client.CopyImageFromOtherPatient(targetStudy, otherPatientId, otherPatientStudyId, otherPatient3DImageId));
            }
        }

        public void RemoveCourse(ESAPIX.Facade.API.Course course)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveCourse(course._client);
                }

                );
            }
            else
            {
                _client.RemoveCourse(course);
            }
        }

        public void RemoveEmptyPhantom(ESAPIX.Facade.API.StructureSet structureset)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.RemoveEmptyPhantom(structureset._client);
                }

                );
            }
            else
            {
                _client.RemoveEmptyPhantom(structureset);
            }
        }

        public Patient()
        {
            _client = (new ExpandoObject());
        }

        public Patient(dynamic client)
        {
            _client = (client);
        }
    }
}