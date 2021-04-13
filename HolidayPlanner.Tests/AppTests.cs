using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HolidayPlanner.Tests
{
    [TestClass]
    public class AppTests
    {

        [TestMethod]
        public void RunPositive()
        {
            var result = App.Run("1.1.2021", "1.1.2022");

            Assert.IsTrue(result.ToLower().Contains("is not valid"));
        }

        [TestMethod]
        public void RunNegative()
        {
            var result = App.Run("1.1.2021", "20.1.2021");

            Assert.IsTrue(result.ToLower().Contains("is valid"));
        }
    }
}
