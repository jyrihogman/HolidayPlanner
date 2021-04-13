using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidayPlanner.DateLogic;
using System;

namespace HolidayPlanner.Tests
{
    [TestClass]
    public class HolidayPlannerTests
    {
        [TestMethod]
        public void IsHolidayValidPositive()
        {
            var startDate = "2021.1.1";
            var endDate = "2021.1.20";

            var (isValid, count) = HolidayPlanner.IsHolidayValid(startDate, endDate);


            Assert.IsTrue(isValid);
            Assert.AreEqual(15, count);
        }

        [TestMethod]
        public void IsHolidayValidNegative()
        {
            var startDate = "2021.1.1";
            var endDate = "2022.1.20";

            var (isValid, count) = HolidayPlanner.IsHolidayValid(startDate, endDate);


            Assert.IsFalse(isValid);
            Assert.AreEqual(315, count);
        }
    }

}
