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
    public class BeamDose : ESAPIX.Facade.API.Dose, System.Xml.Serialization.IXmlSerializable
    {
        public VMS.TPS.Common.Model.Types.DoseValue GetAbsoluteBeamDoseValue(VMS.TPS.Common.Model.Types.DoseValue relative)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetAbsoluteBeamDoseValue(relative));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.DoseValue)))
                    {
                        return default (VMS.TPS.Common.Model.Types.DoseValue);
                    }

                    return (VMS.TPS.Common.Model.Types.DoseValue)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.DoseValue)(_client.GetAbsoluteBeamDoseValue(relative));
            }
        }

        public BeamDose()
        {
            _client = (new ExpandoObject());
        }

        public BeamDose(dynamic client)
        {
            _client = (client);
        }
    }
}