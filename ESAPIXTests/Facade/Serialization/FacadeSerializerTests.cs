#region

using ESAPIX.Facade.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIXTests.Facade.Serialization
{
    [TestClass]
    public class FacadeSerializerTests
    {
        [TestMethod]
        public void SerializeDeserializeDoseValue()
        {
            var doseValue = new DoseValue(25, DoseValue.DoseUnit.Gy);
            var serialized = FacadeSerializer.Serialize(doseValue);

            var deserialized = FacadeSerializer.Deserialize<DoseValue>(serialized);
            Assert.AreEqual(deserialized.Dose, doseValue.Dose);
            Assert.AreEqual(deserialized.Unit, doseValue.Unit);
        }
    }
}