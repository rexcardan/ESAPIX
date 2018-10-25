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
    public class Applicator : ESAPIX.Facade.API.AddOn, System.Xml.Serialization.IXmlSerializable
    {
        public Applicator()
        {
            _client = (new ExpandoObject());
        }

        public Applicator(dynamic client)
        {
            _client = (client);
        }
    }
}