using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class DoseProfile : ESAPIX.Facade.Types.LineProfile
    {
        public DoseProfile() { _client = new ExpandoObject(); }
        public DoseProfile(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public DoseProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, ESAPIX.Facade.Types.DoseValue.DoseUnit unit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructDoseProfile(origin, step, data, unit); });
            else
            {
                _client = new ExpandoObject();
                _client.Origin = origin;
                _client.Step = step;
                _client.Data = data;
                _client.Unit = unit;
            }
        }
        public ESAPIX.Facade.Types.DoseValue.DoseUnit Unit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Unit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue.DoseUnit>((sc) => { return (ESAPIX.Facade.Types.DoseValue.DoseUnit)local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Unit = value; }
            }
        }
    }
}