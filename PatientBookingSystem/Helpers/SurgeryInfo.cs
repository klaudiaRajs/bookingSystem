using System;

namespace PatientBookingSystem.Helpers {
    /** Class is responsible for providing surgery info - created due to limit put on a number of tables */
    class SurgeryInfo {

        /** Surgery contact information */
        string surgeryName = "Tay Court Surgery";
        string firstLineOfAddress = "50 Tay Street";
        string secondLineOfAddress = "DD11 Dundee";
        string phoneNumber = "01382 228228";

        public enum staffTypes { doctor = 1, nurse = 2, administration = 3 };
        public enum userTypes { patient = 1, admin = 2 };
        public enum confirmationMethod { email = 1, call = 2 };
        public static DayOfWeek[] nonWorkingDays = new DayOfWeek[2] { DayOfWeek.Saturday, DayOfWeek.Sunday };
        
        public TimeSpan openingTime;
        public TimeSpan closingTime;
        public int regularAppointmentLength = 15;
        public string defaultConfirmationMethod = SurgeryInfo.confirmationMethod.email.ToString();
        public string defaultUserType = SurgeryInfo.userTypes.patient.ToString();

        
        public SurgeryInfo() {
            openingTime = new TimeSpan(9, 30, 0);
            closingTime = new TimeSpan(17, 45, 0);
        }

        public String getSurgeryName() {
            return this.surgeryName; 
        }

        public String getFirstLineOfAddress() {
            return this.firstLineOfAddress; 
        }

        public String getSecondLineOfAddress() {
            return this.secondLineOfAddress; 
        }

        public String getPhoneNumber() {
            return this.phoneNumber; 
        }
    }
}
