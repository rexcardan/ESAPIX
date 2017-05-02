using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPIX.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.DVH.Query;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Extensions.Tests
{
    [TestClass()]
    public class QueryExtensionsTests
    {
        #region DOSE PRESENTATION
        [TestMethod()]
        public void GetDosePresentationTest1()
        {
            var query = MayoQuery.Read("D90%[cGy]");
            var expected = DoseValuePresentation.Absolute;
            var actual = query.GetDosePresentation();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDosePresentationTest2()
        {
            var query = MayoQuery.Read("D90%[Gy]");
            var expected = DoseValuePresentation.Absolute;
            var actual = query.GetDosePresentation();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDosePresentationTest3()
        {
            var query = MayoQuery.Read("V90Gy[cc]");
            var expected = DoseValuePresentation.Absolute;
            var actual = query.GetDosePresentation();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDosePresentationTest4()
        {
            var query = MayoQuery.Read("V90%[cc]");
            var expected = DoseValuePresentation.Relative;
            var actual = query.GetDosePresentation();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDosePresentationTest5()
        {
            var query = MayoQuery.Read("Mean[cGy]");
            var expected = DoseValuePresentation.Absolute;
            var actual = query.GetDosePresentation();
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DOSE UNIT
        [TestMethod()]
        public void GetDoseUnitTest1()
        {
            var query = MayoQuery.Read("D90%[cGy]");
            var expected = DoseValue.DoseUnit.cGy;
            var actual = query.GetDoseUnit();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDoseUnitTest2()
        {
            var query = MayoQuery.Read("D90%[Gy]");
            var expected = DoseValue.DoseUnit.Gy;
            var actual = query.GetDoseUnit();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDoseUnitTest3()
        {
            var query = MayoQuery.Read("V90Gy[%]");
            var expected = DoseValue.DoseUnit.Gy;
            var actual = query.GetDoseUnit();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDoseUnitTest4()
        {
            var query = MayoQuery.Read("Max[%]");
            var expected = DoseValue.DoseUnit.Percent;
            var actual = query.GetDoseUnit();
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region VOLUME PRESENTATION
        [TestMethod()]
        public void GetVolumePresentationTest1()
        {
            var query = MayoQuery.Read("Max[%]");
            var expected = VolumePresentation.Relative;
            var actual = query.GetVolumePresentation();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVolumePresentationTest2()
        {
            var query = MayoQuery.Read("D90%[cGy]");
            var expected = VolumePresentation.Relative;
            var actual = query.GetVolumePresentation();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVolumePresentationTest3()
        {
            var query = MayoQuery.Read("V90%[cc]");
            var expected = VolumePresentation.AbsoluteCm3;
            var actual = query.GetVolumePresentation();
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}