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
    public class PlanningItemDose : ESAPIX.Facade.API.Dose, System.Xml.Serialization.IXmlSerializable
    {
        public PlanningItemDose()
        {
            _client = (new ExpandoObject());
        }

        public PlanningItemDose(dynamic client)
        {
            _client = (client);
        }
    }
}