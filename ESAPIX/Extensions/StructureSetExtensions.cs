using ESAPIX.Common;
using ESAPIX.Helpers.Strings;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Extensions
{
    public static class StructureSetExtensions
    {
        public static Structure CreateStructureIfNotExists(this StructureSet ss, string id, string dicomType)
        {
            var match = ss.Structures.FirstOrDefault(s => s.Id == id);
            if (match != null) { return match; }

            if (!ss.CanAddStructure(dicomType, id)) { return null; }

            return ss.AddStructure(dicomType, id);
        }

        public static Structure External(this StructureSet ss)
        {
            var match = ss.Structures.FirstOrDefault(s => s.DicomType == MagicStrings.DICOMType.EXTERNAL);
            return match;
        }

        public static Structure Find(this StructureSet ss, string structureId, string regex = null)
        {
            foreach (var struc in ss.Structures)
            {
                var regexMatched = !string.IsNullOrEmpty(regex) &&
                                   Regex.IsMatch(struc.Id, regex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (0 == string.Compare(structureId, struc.Id, true) || regexMatched)
                {
                    return struc; //matched
                }
            }
            return null;
        }

        public static void RemoveAll(this StructureSet ss, string regex)
        {
            var allStructures = ss.Structures.ToList();
            for (int i = allStructures.Count - 1; i >= 0; i--)
            {
                var struc = allStructures[i];
                var regexMatched = !string.IsNullOrEmpty(regex) &&
                   Regex.IsMatch(struc.Id, regex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (regexMatched)
                {
                    if (Environment.UserInteractive)
                    {
                        new ConsoleUI().Write($"Deleting {struc.Id}...");
                    }
                    try
                    {
                        ss.RemoveStructure(struc);
                    }
                    catch (Exception ex)
                    {
                        if (Environment.UserInteractive)
                        {
                            new ConsoleUI().WriteError($"{ex.Message}!");
                        }
                    }

                }
            }
        }

        public static Structure CreateOrResetStructure(this StructureSet ss, string id, string dicomType)
        {
            var str = ss.CreateStructureIfNotExists(id, dicomType);
            str.ClearAllContours(ss.Image);
            return str;
        }
    }
}
