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

        [TestMethod]
        public void SerializeDeserializeDVHPoint()
        {
            var doseValue = new DoseValue(25, DoseValue.DoseUnit.Gy);
            var dp = new DVHPoint(doseValue, 30, "cc");

            var serialized = FacadeSerializer.Serialize(dp);

            var deserialized = FacadeSerializer.Deserialize<DVHPoint>(serialized);
            Assert.AreEqual(deserialized.DoseValue, doseValue);
            Assert.AreEqual(deserialized.Volume, dp.Volume);
            Assert.AreEqual(deserialized.VolumeUnit, dp.VolumeUnit);
        }

        [TestMethod]
        public void SerializeDeserializeVVector()
        {
            var vv = new VVector(5, 6, 7);

            var serialized = FacadeSerializer.Serialize(vv);

            var deserialized = FacadeSerializer.Deserialize<VVector>(serialized);
            Assert.AreEqual(deserialized.x, vv.x);
            Assert.AreEqual(deserialized.y, vv.y);
            Assert.AreEqual(deserialized.z, vv.z);
        }

        [TestMethod]
        public void SerializeDeserializeDoseProfile()
        {
            var v1 = new VVector(1, 2, 3);
            var v2 = new VVector(4, 5, 6);
            var dp = new DoseProfile(v1, v2, new double[] { 0.1, 0.2 }, DoseValue.DoseUnit.Percent);
            var serialized = FacadeSerializer.Serialize(dp);

            var deserialized = FacadeSerializer.Deserialize<DoseProfile>(serialized);
            Assert.AreEqual(deserialized.Count, 2);
            Assert.AreEqual(dp[0], deserialized[0]);
            Assert.AreEqual(dp[1], deserialized[1]);
            Assert.AreEqual(dp.Unit, deserialized.Unit);
        }
    }
}