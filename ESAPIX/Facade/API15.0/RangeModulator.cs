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
    public class RangeModulator : ESAPIX.Facade.API.AddOn, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.RangeModulatorType Type
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Type"))
                    {
                        return _client.Type;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.RangeModulatorType);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Type;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.RangeModulatorType);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Type = (value);
                }
                else
                {
                }
            }
        }

        public RangeModulator()
        {
            _client = (new ExpandoObject());
        }

        public RangeModulator(dynamic client)
        {
            _client = (client);
        }
    }
}