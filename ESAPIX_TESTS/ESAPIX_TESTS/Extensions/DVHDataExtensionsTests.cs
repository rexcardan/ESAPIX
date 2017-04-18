using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPIX.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.Types;
using static ESAPIX.Facade.Types.DoseValue.DoseUnit;

namespace ESAPIX.Extensions.Tests
{
    [TestClass()]
    public class DVHDataExtensionsTests
    {
        [TestMethod()]
        public void ConvertToRelativeDoseTest()
        {
            var dvh = new DVHPoint[]
            {
                new DVHPoint(new DoseValue(0, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(50, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(100, cGy), 0, "cc"),
                 new DVHPoint(new DoseValue(200, cGy), 0, "cc")
            };

            var relative = dvh.ConvertToRelativeDose(new DoseValue(100, cGy));
            Assert.AreEqual(relative[0].DoseValue.Dose, 0, 0.0001);
            Assert.AreEqual(relative[1].DoseValue.Dose, 50, 0.0001);
            Assert.AreEqual(relative[2].DoseValue.Dose, 100, 0.0001);
            Assert.AreEqual(relative[3].DoseValue.Dose, 200, 0.0001);
        }

        [TestMethod()]
        public void ConvertToRelativeVolumeTest()
        {
            var dvh = new DVHPoint[]
            {
                new DVHPoint(new DoseValue(0, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(100, cGy), 100, "cc"),
                new DVHPoint(new DoseValue(200, cGy), 200, "cc")
            };

            var relative = dvh.ConvertToRelativeVolume();
            Assert.AreEqual(relative[0].Volume, 0, 0.0001);
            Assert.AreEqual(relative[1].Volume, 50, 0.0001);
            Assert.AreEqual(relative[2].Volume, 100, 0.0001);
        }

        [TestMethod()]
        public void MaxDoseTest()
        {
            var dvh = new DVHPoint[]
   {
                new DVHPoint(new DoseValue(1, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(50, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(101, cGy), 0, "cc")
   };

            var actual = dvh.MaxDose();
            var expected = new DoseValue(101, cGy);
            Assert.AreEqual(expected.Dose, actual.Dose, 0.0001);
        }

        [TestMethod()]
        public void MinDoseTest()
        {
            var dvh = new DVHPoint[]
        {
                new DVHPoint(new DoseValue(1, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(50, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(100, cGy), 0, "cc")
        };

            var actual = dvh.MinDose();
            var expected = new DoseValue(1, cGy);
            Assert.AreEqual(expected.Dose, actual.Dose, 0.0001);
        }

        [TestMethod()]
        public void MeanDoseTest()
        {
            var dvh = new DVHPoint[]
           {
                new DVHPoint(new DoseValue(0, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(50, cGy), 0, "cc"),
                new DVHPoint(new DoseValue(100, cGy), 0, "cc")
           };

            var actual = dvh.MeanDose();
            var expected = new DoseValue(50, cGy);
            Assert.AreEqual(expected.Dose, actual.Dose, 0.0001);
        }
    }
}