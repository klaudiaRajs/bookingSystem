using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    public partial class personalInformationPanel : UserControl {

        UserModel user;
        UserRepo repo; 
         
        public personalInformationPanel() {
            InitializeComponent();
            repo = new UserRepo(); 
            user = repo.getUserByLoginCredentials(ApplicationState.userLogin, ApplicationState.userPassword); 
            fillInPersonalInformation(); 
        }

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

        private string getTheMostOftenAttendedStaffMember() {
            BookingRepo bookingRepo = new BookingRepo(); 
            return bookingRepo.getTheMostOftenAttendedDoctor(); 
        }

        protected String getDateInPresenterFormat(String date) {
            string[] separator = new string[] { ".", " " };
            string[] dateContent = date.Split(separator, StringSplitOptions.None);
            DateTime newDate = new DateTime(Int32.Parse(dateContent[2]), Int32.Parse(dateContent[1]), Int32.Parse(dateContent[0]));
            String dateInFormat = newDate.ToString("dddd dd MMMM, yyyy");
            return dateInFormat;
        }

    }
}
