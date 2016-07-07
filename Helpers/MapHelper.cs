using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers
{
    public class MapHelper
    {
        public static object MapDefault(object obj)
        {
            var stype = obj.GetType();
            var destType = Mapper.Instance.ConfigurationProvider.GetAllTypeMaps().
              Where(map => map.SourceType == stype).
              Single().
              DestinationType;
            return Mapper.Map(obj, stype, destType);
        }
    }
}
