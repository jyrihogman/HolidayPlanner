using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidayPlanner.HolidayLogic;

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
            
            var (result, count) = HolidayPlanner.ValidateHoliday(startDate, endDate);


            Assert.AreEqual(result, ValidationResult.Ok);
            Assert.AreEqual(15, count);
        }

        [TestMethod]
        public void ValidateHolidayNegative()
        {
            var startDate = "2021.7.1";
            var endDate = "2021.8.31";

            var (result, count) = HolidayPlanner.ValidateHoliday(startDate, endDate);


            Assert.AreEqual(result, ValidationResult.TooManyDays);
            Assert.AreEqual(53, count);
        }
    }

}
