using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers.Tests {
    [TestClass()]
    public class ValidatorTests {

        /** Method tests if the validator returns true when correct data provided */
        [TestMethod()]
        public void validateStaffScheduleTest() {
            bool expected = true;
            int staffId = 1;
            List<int> schedules = new List<int> { 1, 2, 3, 5 };
            bool result = Validator.validateStaffSchedule(staffId, schedules);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when there are no schedules id provided */
        [TestMethod()]
        public void validateStaffScheduleTestNoSchedules() {
            bool expected = false;
            int staffId = 2;
            List<int> schedules = new List<int> { };
            bool result = Validator.validateStaffSchedule(staffId, schedules);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when there are no staff id provided */
        [TestMethod()]
        public void validateStaffScheduleTestNoStaff() {
            bool expected = false;
            int staffId = 0;
            List<int> schedules = new List<int> { 1, 2, 4, 5 };
            bool result = Validator.validateStaffSchedule(staffId, schedules);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when there are no schedules id provided */
        [TestMethod()]
        public void validateStaffScheduleTestNoStaffNoSchedules() {
            bool expected = false;
            int staffId = 0;
            List<int> schedules = new List<int> { };
            bool result = Validator.validateStaffSchedule(staffId, schedules);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns true when only correct staff member model passed */
        [TestMethod()]
        public void validateStaffMemberTest() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("John");
            staffMember.setLastName("Smith");
            int expected = 0;
            int result = Validator.validateStaffMember(staffMember).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when only incorrect staff member model passed */
        [TestMethod()]
        public void validateStaffMemberTestIncorrectStaffMemberNoStaffType() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("John");
            staffMember.setLastName("");
            int expected = 1;
            int result = Validator.validateStaffMember(staffMember).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when only incorrect staff member model passed */
        [TestMethod()]
        public void validateStaffMemberTestIncorrectStaffMemberNoStaffType2() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("");
            staffMember.setLastName("Smith");
            int expected = 1;
            int result = Validator.validateStaffMember(staffMember).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when only incorrect staff member model passed */
        [TestMethod()]
        public void validateStaffMemberTestIncorrectStaffMemberNoStaffType3() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("");
            staffMember.setLastName("");
            int expected = 2;
            int result = Validator.validateStaffMember(staffMember).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when incorrect staff member model passed and correct staff type*/
        [TestMethod()]
        public void validateStaffMemberTestIncorrectStaffMemberCorrectStaffType() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("");
            staffMember.setLastName("");
            int staffType = 2;
            int expected = 2;
            int result = Validator.validateStaffMember(staffMember, staffType).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when correct staff member model passed and incorrect staff type*/
        [TestMethod()]
        public void validateStaffMemberTestCorrectStaffMemberIncorrectStaffType() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("John");
            staffMember.setLastName("Smith");
            int staffType = 0;
            int expected = 1;
            int result = Validator.validateStaffMember(staffMember, staffType).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns false when correct staff member model passed and correct staff type*/
        [TestMethod()]
        public void validateStaffMemberTestCorrectStaffMemberCorrectStaffType() {
            StaffModel staffMember = new StaffModel();
            staffMember.setFirstName("John");
            staffMember.setLastName("Smith");
            int staffType = 1;
            int expected = 0;
            int result = Validator.validateStaffMember(staffMember, staffType).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 0 when correct user passed*/
        [TestMethod()]
        public void validateUserTest() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Address address");
            user.setUserType("admin");

            int expected = 0;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect email - no dot*/
        [TestMethod()]
        public void validateUserTestIncorrectEmail() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@emailpl");
            user.setAddress("Address address");
            user.setUserType("admin");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect email - no at*/
        [TestMethod()]
        public void validateUserTestIncorrectEmail2() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("emailemail.pl");
            user.setAddress("Address address");
            user.setUserType("admin");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect address - no space*/
        [TestMethod()]
        public void validateUserTestIncorrectAddress() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Addressaddress");
            user.setUserType("patient");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect firstName */
        [TestMethod()]
        public void validateUserTestIncorrectFirstName() {
            UserModel user = new UserModel();
            user.setFirstName("");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Address address");
            user.setUserType("patient");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect lastName */
        [TestMethod()]
        public void validateUserTestIncorrectLastName() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Address address");
            user.setUserType("patient");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect login */
        [TestMethod()]
        public void validateUserTestIncorrectLogin() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Address address");
            user.setUserType("patient");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect password */
        [TestMethod()]
        public void validateUserTestIncorrectPassword() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Address address");
            user.setUserType("patient");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if the validator returns list of errors with length 1 when incorrect uset type */
        [TestMethod()]
        public void validateUserTestIncorrectUserType() {
            UserModel user = new UserModel();
            user.setFirstName("John");
            user.setLastName("Smith");
            user.setLogin("johnSmith");
            user.setPassword("password");
            user.setDOBd(new DateTime(2001, 12, 1));
            user.setEmailAddress("email@email.pl");
            user.setAddress("Address address");
            user.setUserType("test");

            int expected = 1;
            int result = Validator.validateUser(user).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if login information provided meet the requirements */
        [TestMethod()]
        public void validateLoggerTest() {
            bool expected = true;
            bool result = Validator.validateLogger("John", "Smith");
            Assert.AreEqual(expected, result);
        }

        /** Method tests if login information provided meet the requirements */
        [TestMethod()]
        public void validateLoggerTestTooShortLogin() {
            bool expected = false;
            bool result = Validator.validateLogger("A", "Smith");
            Assert.AreEqual(expected, result);
        }

        /** Method tests if login information provided meet the requirements */
        [TestMethod()]
        public void validateLoggerTestTooShortPassword() {
            bool expected = false;
            bool result = Validator.validateLogger("John", "A");
            Assert.AreEqual(expected, result);
        }

        /** Method tests if absence validator returns list of length 0 when valid model passed */
        [TestMethod()]
        public void validateAbsenceForSavingTest() {
            AbsenceModel absence = new AbsenceModel();
            absence.startDate = "2018-04-06";
            int expected = 0;
            int result = Validator.validateAbsenceForSaving(absence).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if absence validator returns list of length 1 when invalid model passed */
        [TestMethod()]
        public void validateAbsenceForSavingTestInvalidData() {
            AbsenceModel absence = new AbsenceModel();
            absence.startDate = "2013-04-06";
            int expected = 1;
            int result = Validator.validateAbsenceForSaving(absence).Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if validator returns list of 0 when valid credentials are passed */
        [TestMethod()]
        public void validateLoginCredentialsTestValid() {
            int expected = 0;
            int result = Validator.validateLoginCredentials("john", "smith").Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if validator returns list of 2 when invalid credentials are passed */
        [TestMethod()]
        public void validateLoginCredentialsTestInvalid() {
            int expected = 2;
            int result = Validator.validateLoginCredentials("", "").Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if validator returns list of 1 when invalid credentials are passed */
        [TestMethod()]
        public void validateLoginCredentialsTestInvalidSingleField() {
            int expected = 1;
            int result = Validator.validateLoginCredentials("john", "").Count;
            Assert.AreEqual(expected, result);
        }

        /** Method tests if validator returns true when booking contains valid id*/
        [TestMethod()]
        public void validateBookingForUpdateTestCorrect() {
            BookingModel booking = new BookingModel();
            booking.setId(2);
            bool expected = true;
            bool result = Validator.validateBookingForUpdate(booking);
            Assert.AreEqual(expected, result);
        }


        /** Method tests if validator returns false when booking contains valid id*/
        [TestMethod()]
        public void validateBookingForUpdateTestIncorrect() {
            BookingModel booking = new BookingModel();
            booking.setId(0);
            bool expected = false;
            bool result = Validator.validateBookingForUpdate(booking);
            Assert.AreEqual(expected, result);
        }
    }
}