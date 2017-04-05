using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PatientBookingSystem.Models.Tests {
    [TestClass()]
    public class UserModelTests {

        /** Method tests if intance returns correctly formatted string created DateTime object */
        [TestMethod()]
        public void getDobInMySqlFormatTest() {
            UserModel instance = new UserModel();
            instance.setDOBd(new DateTime(2015, 3, 15));
            string expected = "2015-03-15";
            string result = instance.getDobInMySqlFormat();
            Assert.AreEqual(expected, result);
        }
    }
}