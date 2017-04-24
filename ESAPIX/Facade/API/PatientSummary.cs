using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class PatientSummary : ESAPIX.Facade.API.SerializableObject
    {
        public PatientSummary() { _client = new ExpandoObject(); }
        public PatientSummary(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
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
        public System.String Id
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Id; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Id = value; }
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
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
    }
}