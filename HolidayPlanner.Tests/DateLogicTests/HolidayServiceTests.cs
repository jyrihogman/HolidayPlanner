using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidayPlanner.DateLogic;
using System;

namespace HolidayPlanner.Tests
{
    [TestClass]
    public class HolidayPlannerServiceTests
    {

        [TestMethod]
        public void GetConsumedHolidays()
        {
            var startDate = new DateTime(2021, 1, 1);
            var endDate = new DateTime(2021, 1, 20);

            var dateTimeArray = HolidayPlannerService.GetConsumedHolidays(startDate, endDate, "Finland");

            Assert.AreEqual(dateTimeArray.Count, 15);
        }

        [TestMethod]
        public void IsHolidayValidPositive()
        {
            var isValid = HolidayPlannerService.IsHolidayValid(45);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsHolidayValidPositiveMax()
        {
            var isValid = HolidayPlannerService.IsHolidayValid(50);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsHolidayValidNegative()
        {
            var isValid = HolidayPlannerService.IsHolidayValid(51);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsSundayPositive()
        {
            var isSunday = HolidayPlannerService.IsSunday(
                new DateTime(2021, 4, 11));

            Assert.IsTrue(isSunday);
        }

        [TestMethod]
        public void IsSundayNegative()
        {
            var isSunday = HolidayPlannerService.IsSunday(
                new DateTime(2021, 4, 12));

            Assert.IsFalse(isSunday);
        }


        [TestMethod]
        public void IsNationalHolidayPositive()
        {
            var isNationalHoliday = HolidayPlannerService.IsNationalHoliday(
                new DateTime(2021, 1, 1), "Finland");

            Assert.IsTrue(isNationalHoliday);
        }

        [TestMethod]
        public void IsNationalHolidayNegative()
        {
            var isNationalHoliday = HolidayPlannerService.IsNationalHoliday(
                new DateTime(2021, 1, 4), "Finland");

            Assert.IsFalse(isNationalHoliday);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IsNationalHolidayCountryNotSupported()
        {
            var isNationalHoliday = HolidayPlannerService.IsNationalHoliday(
                new DateTime(2021, 1, 1), "Sweden");
        }
    }
}
