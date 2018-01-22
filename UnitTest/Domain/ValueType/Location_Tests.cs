using Domain.ValueType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Domain.ValueType
{
    [TestClass]
    public class Location_Tests
    {
        [TestMethod]
        public void ShouldBeEqualsByReference()
        {
            Location locationA = new Location(2, 2);

            Assert.IsTrue(locationA.Equals(locationA));
        }

        [TestMethod]
        public void ShouldBeEqualsByProperties()
        {
            Location locationA = new Location(2, 2);
            Location locationB = new Location(2, 2);

            Assert.IsTrue(locationA.Equals(locationB));
        }

        [TestMethod]
        public void ShouldBeEqualsWithOperator()
        {
            Location locationA = new Location(2, 2);
            Location locationB = new Location(2, 2);

            Assert.IsTrue(locationA == locationB);
        }

        [TestMethod]
        public void ShouldNotBeEqualsWithNullObject()
        {
            Location locationA = new Location(2, 2);

            Assert.IsFalse(locationA.Equals(null));
        }

        [TestMethod]
        public void ShouldNotBeEqualsWithProperties()
        {
            Location locationA = new Location(2, 2);
            Location locationB = new Location(2, 3);

            Assert.IsFalse(locationA.Equals(locationB));
        }

        [TestMethod]
        public void ShouldNotBeEqualsWithOperator()
        {
            Location locationA = new Location(2, 2);
            Location locationB = new Location(2, 3);

            Assert.IsTrue(locationA != locationB);
        }
    }
}
