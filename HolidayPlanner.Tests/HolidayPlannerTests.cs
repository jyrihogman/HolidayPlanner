using System;
using HolidayPlanner.DateLogic;
using HolidayPlanner.HolidayLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HolidayPlanner.Tests
{
    [TestClass]
    public class HolidayPlannerTests
    {

        public Mock<IDateWrapper> dateWrapper;

        [TestInitialize]
        public void SetupTest()
        {
            dateWrapper = new Mock<IDateWrapper>();
            dateWrapper.Setup(t => t.GetToday())
                .Returns(new DateTime(2021, 5, 1));
        }

        [TestMethod]
        public void IsHolidayValidPositive()
        {
            var holidayService = new HolidayService(dateWrapper.Object);
            var holidayPlanner = new HolidayPlanner(holidayService);

            var startDate = "2021.7.1";
            var endDate = "2021.7.7";
            
            var (result, count) = holidayPlanner.ValidateHoliday(startDate, endDate);


            Assert.AreEqual(ValidationResult.Ok, result);
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void ValidateHolidayNegative()
        {
            var holidayService = new HolidayService(dateWrapper.Object);
            var holidayPlanner = new HolidayPlanner(holidayService);

            var startDate = "2021.7.1";
            var endDate = "2021.8.31";


            var (result, count) = holidayPlanner.ValidateHoliday(startDate, endDate);


            Assert.AreEqual(ValidationResult.TooManyDays, result);
            Assert.AreEqual(53, count);
        }
    }

}
