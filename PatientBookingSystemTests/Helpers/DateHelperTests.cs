using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientBookingSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers.Tests {
    [TestClass()]
    public class DateHelperTests {
        [TestMethod()]
        public void convertToLastDayOfMonthTest() {
            DateTime expected = new DateTime(2017, 3, 31);
            DateTime result = DateHelper.convertToLastDayOfMonth(new DateTime(2017, 3, 15));
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateTimeObjectFromStringTestMySQL() {
            DateTime expected = new DateTime(2017, 3, 31);
            DateTime result = DateHelper.getDateTimeObjectFromString("2017-03-31");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateTimeObjectFromStringTestDotted() {
            DateTime expected = new DateTime(2017, 3, 31);
            DateTime result = DateHelper.getDateTimeObjectFromString("31.03.2017");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateTimeObjectFromStringTestSlashSeparator() {
            DateTime expected = new DateTime(2017, 3, 31);
            DateTime result = DateHelper.getDateTimeObjectFromString("31\\03\\2017");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateTimeObjectFromStringTestBackslashSeparator() {
            DateTime expected = new DateTime(2017, 3, 31);
            DateTime result = DateHelper.getDateTimeObjectFromString("31/03/2017");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateInMySqlFormatTestDifferentOrder() {
            string expected = "2017-03-31";
            string result = DateHelper.getDateInMySqlFormat("31-03-2017");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateInMySqlFormatTestDotted() {
            string expected = "2017-03-31";
            string result = DateHelper.getDateInMySqlFormat("31.03.2017");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateInMySqlFormatTestWithSlash() {
            string expected = null;
            string result = DateHelper.getDateInMySqlFormat("31/03/2017");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getDateInMySqlFormatTestNotHandled() {
            string expected = "2017-03-31";
            string result = DateHelper.getDateInMySqlFormat("2017-03-31");
            Assert.AreEqual(expected, result);
        }
    }
}