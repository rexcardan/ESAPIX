using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPIX.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using static ESAPIX.Helpers.MagicStrings;

namespace ESAPIX.Constraints.Tests
{
    [TestClass()]
    public class PQAsserterTests
    {
        [TestMethod()]
        public void ContainsOneOrMoreNonEmptyStructureByIdTest()
        {
            var ps = new PlanSetup()
            {
                StructureSet = new StructureSet()
                {
                    Structures = new List<Structure>()
                    {
                        new Structure(){Id = "PTV", IsEmpty = false, DicomType = DICOMType.PTV },
                        new Structure(){Id = "PTV2", IsEmpty = true, DicomType = DICOMType.PTV },
                        new Structure(){Id = "BODY", IsEmpty = false, DicomType = DICOMType.NONE }
                    }
                }
            };

            //PASSING
            var expected = ResultType.PASSED;
            var actual = new PQAsserter().ContainsOneOrMoreNonEmptyStructureById(ps, "PTV", "PTV2");
            Assert.AreEqual(expected, actual.CumulativeResult.ResultType);

            //FAILING
            expected = ResultType.NOT_APPLICABLE;
            actual = new PQAsserter().ContainsOneOrMoreNonEmptyStructureById(ps, "PTV2");
            Assert.AreEqual(expected, actual.CumulativeResult.ResultType);
        }

        [TestMethod()]
        public void ContainsOneOrMoreNonEmptyStructuresByDICOMTypeTest()
        {
            var ps = new PlanSetup()
            {
                StructureSet = new StructureSet()
                {
                    Structures = new List<Structure>()
                    {
                        new Structure(){Id = "PTV", IsEmpty = false, DicomType = DICOMType.PTV },
                        new Structure(){Id = "PTV2", IsEmpty = true, DicomType = DICOMType.PTV },
                        new Structure(){Id = "BODY", IsEmpty = false, DicomType = DICOMType.NONE }
                    }
                }
            };

            //PASSING
            var expected = ResultType.PASSED;
            var actual = new PQAsserter().ContainsOneOrMoreNonEmptyStructuresByDICOMType(ps, DICOMType.PTV, DICOMType.GTV);
            Assert.AreEqual(expected, actual.CumulativeResult.ResultType);

            //FAILING
            expected = ResultType.NOT_APPLICABLE;
            actual = new PQAsserter().ContainsOneOrMoreNonEmptyStructuresByDICOMType(ps, DICOMType.GTV, DICOMType.CAVITY);
            Assert.AreEqual(expected, actual.CumulativeResult.ResultType);
        }
    }
}