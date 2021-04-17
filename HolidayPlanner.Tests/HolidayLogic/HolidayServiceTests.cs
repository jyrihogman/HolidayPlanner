using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidayPlanner.HolidayLogic;
using System;
using HolidayPlanner.DateLogic;
using Moq;

namespace HolidayPlanner.Tests
{
    [TestClass]
    public class HolidayServiceTests
    {

        public Mock<IDateWrapper> dateWrapper;
        private IHolidayService holidayService;

        [TestInitialize]
        public void SetupTest()
        {
            dateWrapper = new Mock<IDateWrapper>();
            dateWrapper.Setup(t => t.GetToday())
                .Returns(new DateTime(2021, 5, 1));

            holidayService = new HolidayService(dateWrapper.Object);
        }

        [TestMethod]
        public void IsOnSameHolidayPeriod()
        {
            var startDate = new DateTime(2021, 5, 3);
            var endDate = new DateTime(2021, 5, 20);

            var isSamePeriod = holidayService.IsOnSameHolidayPeriod(startDate, endDate);

            Assert.IsTrue(isSamePeriod);
        }

        [TestMethod]
        public void IsOnSameHolidayPeriodPast()
        {
            var startDate = new DateTime(2021, 3, 1);
            var endDate = new DateTime(2021, 4, 20);

            var isSamePeriod = holidayService.IsOnSameHolidayPeriod(startDate, endDate);

            Assert.IsFalse(isSamePeriod);
        }

        [TestMethod]
        public void IsOnSameHolidayPeriodNegative()
        {
            var startDate = new DateTime(2022, 3, 30);
            var endDate = new DateTime(2022, 4, 5);

            var isSamePeriod = holidayService.IsOnSameHolidayPeriod(startDate, endDate);

            Assert.IsFalse(isSamePeriod);
        }

        [TestMethod]
        public void GetConsumedHolidays()
        {
            var startDate = new DateTime(2021, 1, 1);
            var endDate = new DateTime(2021, 1, 20);

            var dateTimeArray = HolidayService.GetConsumedHolidays(startDate, endDate, "Finland");

            Assert.AreEqual(dateTimeArray.Count, 15);
        }

        [TestMethod]
        public void IsHolidayValidPositive()
        {
            var isValid = HolidayService.IsHolidayLengthValid(45);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsHolidayValidPositiveMax()
        {
            var isValid = HolidayService.IsHolidayLengthValid(50);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsHolidayValidNegative()
        {
            var isValid = HolidayService.IsHolidayLengthValid(51);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsSundayPositive()
        {
            var isSunday = HolidayService.IsSunday(
                new DateTime(2021, 4, 11));

            Assert.IsTrue(isSunday);
        }

        [TestMethod]
        public void IsSundayNegative()
        {
            var isSunday = HolidayService.IsSunday(
                new DateTime(2021, 4, 12));

            Assert.IsFalse(isSunday);
        }


        [TestMethod]
        public void IsNationalHolidayPositive()
        {
            var isNationalHoliday = HolidayService.IsNationalHoliday(
                new DateTime(2021, 1, 1), "Finland");

            Assert.IsTrue(isNationalHoliday);
        }

        [TestMethod]
        public void IsNationalHolidayNegative()
        {
            var isNationalHoliday = HolidayService.IsNationalHoliday(
                new DateTime(2021, 1, 4), "Finland");

            Assert.IsFalse(isNationalHoliday);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IsNationalHolidayCountryNotSupported()
        {
            var isNationalHoliday = HolidayService.IsNationalHoliday(
                new DateTime(2021, 1, 1), "Sweden");
        }
    }
}
