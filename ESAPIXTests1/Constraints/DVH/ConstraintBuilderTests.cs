using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPIX.Constraints.DVH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Constraints.DVH.Tests
{
    [TestClass()]
    public class ConstraintBuilderTests
    {
        [TestMethod()]
        public void BuildMaxDoseTest()
        {
            var con = ConstraintBuilder.Build("Prostate", "Max[Gy] < 77");
            Assert.IsTrue(con.GetType() == typeof(MaxDoseConstraint));
            Assert.AreEqual((con as MaxDoseConstraint).StructureName, "Prostate");
            Assert.AreEqual((con as MaxDoseConstraint).Dose, 77, 0.01);
        }
    }
}