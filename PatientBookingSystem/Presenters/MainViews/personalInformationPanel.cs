using System;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem {
    /** Class is responsible for managing personal information panel and communicating with relevant controllers */
    public partial class personalInformationPanel : UserControl {

        UserModel user;
        
        /** Constructor prepares view */ 
        public personalInformationPanel() {
            InitializeComponent();
            UserController userController = new UserController();  
            user = userController.getUserByLoginCredentials(ApplicationState.userLogin, ApplicationState.userPassword); 
            fillInPersonalInformation(); 
            if( ApplicationState.userType == "admin") {
                personalStatistics.Visible = false;
            }
        }

        /** Method fills in all the user information (view) */
        private void fillInPersonalInformation() {
            firstNameLabel.Text = user.getFirstName();
            lastNameLabel.Text = user.getLastName();
            phoneNumberLabel.Text = user.getPhoneNumber();
            user.getDobInMySqlFormat();
            DobLabel.Text = user.getDOBd().ToString("yyyy-MM-dd");
            NiNLabel.Text = user.getNiN();
            emailLabel.Text = user.getEmail();
            theMostOftenAttendedStaffMemberLabel.Text = getTheMostOftenAttendedStaffMember();
        }

        /** Method returns the most often attended staff member for the user */
        private string getTheMostOftenAttendedStaffMember() {
            BookingController bookingController = new BookingController(); 
            return bookingController.getFullNameOfTheMostOftenAttendedDoctor(); 
        }

        /** Method returns date in prestable format */
        protected String getDateInPresenterFormat(String date) {
            string[] separator = new string[] { ".", " " };
            string[] dateContent = date.Split(separator, StringSplitOptions.None);
            DateTime newDate = new DateTime(Int32.Parse(dateContent[2]), Int32.Parse(dateContent[1]), Int32.Parse(dateContent[0]));
            String dateInFormat = newDate.ToString("dddd dd MMMM, yyyy");
            return dateInFormat;
        }
    }
}
