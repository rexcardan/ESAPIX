using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ControlPointParameters
    {
        internal dynamic _client;
        public ControlPointParameters() { }
        public ControlPointParameters(dynamic client) { _client = client; }
        public System.Double CollimatorAngle
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.CollimatorAngle; });
            }
        }
        public System.Double GantryAngle
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.GantryAngle; });
            }
        }
        public ESAPIX.Facade.Types.VRect<System.Double> JawPositions
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VRect<System.Double>(local._client.JawPositions);
            }
        }
        public System.Single[,] LeafPositions
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Single[,]>((sc) => { return local._client.LeafPositions; });
            }
        }
        public System.Double MetersetWeight
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MetersetWeight; });
            }
        }
        public System.Double PatientSupportAngle
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PatientSupportAngle; });
            }
        }
        public System.Double TableTopLateralPosition
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TableTopLateralPosition; });
            }
        }
        public System.Double TableTopLongitudinalPosition
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TableTopLongitudinalPosition; });
            }
        }
        public System.Double TableTopVerticalPosition
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.TableTopVerticalPosition; });
            }
        }
    }
}