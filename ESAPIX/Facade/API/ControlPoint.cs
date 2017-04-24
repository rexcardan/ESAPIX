using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ControlPoint : ESAPIX.Facade.API.SerializableObject
    {
        public ControlPoint() { _client = new ExpandoObject(); }
        public ControlPoint(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Double CollimatorAngle
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CollimatorAngle; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.CollimatorAngle; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CollimatorAngle = value; }
            }
        }
        public System.Double GantryAngle
        {
            get
            {
                if (_client is ExpandoObject) { return _client.GantryAngle; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.GantryAngle; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.GantryAngle = value; }
            }
        }
        public ESAPIX.Facade.Types.VRect<System.Double> JawPositions
        {
            get
            {
                if (_client is ExpandoObject) { return _client.JawPositions; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VRect<System.Double>>((sc) => { return new ESAPIX.Facade.Types.VRect<System.Double>(local._client.JawPositions); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.JawPositions = value; }
            }
        }
        public System.Single[,] LeafPositions
        {
            get
            {
                if (_client is ExpandoObject) { return _client.LeafPositions; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Single[,]>((sc) => { return local._client.LeafPositions; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.LeafPositions = value; }
            }
        }
        public System.Double MetersetWeight
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MetersetWeight; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MetersetWeight; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MetersetWeight = value; }
            }
        }
        public System.Double PatientSupportAngle
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PatientSupportAngle; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PatientSupportAngle; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PatientSupportAngle = value; }
            }
        }
        public System.Double TableTopLateralPosition
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TableTopLateralPosition; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TableTopLateralPosition; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TableTopLateralPosition = value; }
            }
        }
        public System.Double TableTopLongitudinalPosition
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TableTopLongitudinalPosition; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TableTopLongitudinalPosition; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TableTopLongitudinalPosition = value; }
            }
        }
        public System.Double TableTopVerticalPosition
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TableTopVerticalPosition; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TableTopVerticalPosition; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TableTopVerticalPosition = value; }
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