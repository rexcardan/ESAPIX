using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class DoseProfile : ESAPIX.Facade.Types.LineProfile
    {
        public DoseProfile() { }
        public DoseProfile(dynamic client) { _client = client; }
        public DoseProfile(ESAPIX.Facade.Types.VVector origin, ESAPIX.Facade.Types.VVector step, System.Double[] data, ESAPIX.Facade.Types.DoseValue.DoseUnit unit) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructDoseProfile(origin, step, data, unit)); }
        public ESAPIX.Facade.Types.DoseValue.DoseUnit Unit
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.DoseValue.DoseUnit)local._client.Unit;
            }
        }
    }
}