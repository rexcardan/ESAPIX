#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class DoseProfile : LineProfile
    {
        public DoseProfile()
        {
            _client = new ExpandoObject();
        }

        public DoseProfile(dynamic client)
        {
            _client = client;
        }

        public DoseProfile(VVector origin, VVector step, double[] data, DoseValue.DoseUnit unit)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructDoseProfile(origin, step, data, unit);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DoseValue.DoseUnit Unit
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Unit") ? _client.Unit : default(DoseValue.DoseUnit);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc => { return (DoseValue.DoseUnit) local._client.Unit; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Unit = value;
            }
        }
    }
}