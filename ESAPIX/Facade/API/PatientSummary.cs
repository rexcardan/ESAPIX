#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class PatientSummary : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public PatientSummary()
        {
            _client = new ExpandoObject();
        }

        public PatientSummary(dynamic client)
        {
            _client = client;
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

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Id"))
                        return _client.Id;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Id; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Id = value;
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
                {
                    _client.SSN = value;
                }
            }
        }
    }
}