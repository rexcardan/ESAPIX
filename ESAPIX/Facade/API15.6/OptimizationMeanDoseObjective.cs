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
    public class OptimizationMeanDoseObjective : ESAPIX.Facade.API.OptimizationObjective, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.DoseValue Dose
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Dose"))
                    {
                        return _client.Dose;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Dose;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DoseValue);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Dose = (value);
                }
                else
                {
                }
            }
        }

        public OptimizationMeanDoseObjective()
        {
            _client = (new ExpandoObject());
        }

        public OptimizationMeanDoseObjective(dynamic client)
        {
            _client = (client);
        }
    }
}