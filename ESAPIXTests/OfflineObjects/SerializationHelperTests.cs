#region

using System.Linq;
using ESAPIX.OfflineObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace ESAPIX_TESTS.Helpers
{
    [TestClass]
    public class OfflineObjectsTests
    {
        [TestMethod]
        public void TestCanGetPlan()
        {
            var plan = Samples.GetProstatePlanSetup();
            var beams = plan.Beams.Count();
            Assert.AreEqual(beams, 7);
        }
    }
}