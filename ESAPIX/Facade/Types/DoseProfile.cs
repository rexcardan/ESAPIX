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
        public DoseProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, ESAPIX.Facade.Types.DoseValue.DoseUnit unit) { X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructDoseProfile(origin, step, data, unit); }); }
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