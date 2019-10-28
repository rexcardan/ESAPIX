using System.Linq;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Extensions
{
    public static class StructureSetExtensions
    {
        public static Structure CreateStructureIfNotExists(this StructureSet ss, string id, string dicomType)
        {
            var match = ss.Structures.FirstOrDefault(s => s.Id == id);
            if (match != null) { return match; }

            if(!ss.CanAddStructure(dicomType, id)) { return null; }

            return ss.AddStructure(dicomType, id);
        }
    }
}
