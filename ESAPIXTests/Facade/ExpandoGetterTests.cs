#region

using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace ESAPIX.Facade.Tests
{
    [TestClass]
    public class ExpandoGetterTests
    {
        [TestMethod]
        public void GetClientTest()
        {
            var offline = ESAPIX.OfflineObjects.Samples.GetProstatePlanSetup();
            var client = ExpandoGetter.GetClient(offline);
            client.Id = "TEST";
            Assert.IsNotNull((object) client);
            Assert.AreEqual(offline.Id, "TEST");
            Assert.IsTrue(client is ExpandoObject);
        }
    }
}