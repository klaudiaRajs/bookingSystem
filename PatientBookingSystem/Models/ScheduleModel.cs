using System;

namespace PatientBookingSystem.Models {
    /** Class is a database model of schedule table - contains all the getters and setters */
    public class ScheduleModel : IModel {

        private int scheduleId;
        private string date;
        private string startTime;
        private string endTime;
        private StaffModel staffMember; 

        public StaffModel getStaffMember() {
            return this.staffMember; 
        }

        public void setStaffMember(StaffModel staffMember) {
            this.staffMember = staffMember; 
        }

        public int getScheduleId() {
            return this.scheduleId;
        }

        public void setScheduleId(int scheduleId) {
            this.scheduleId = scheduleId;
        }

        public string getDate() {
            return this.date; 
        }

        /** 
         * Method sets model's date and if required deletes time part from date string 
         * 
         * @param date
         */
        public void setDate(string date) {
            bool isDateTime = date.IndexOf(" ") >= 0;
            if (isDateTime) {
                date = date.Remove(date.IndexOf(" "));
            }
            this.date = date; 
        }

        public string getStartTime() {
            return this.startTime; 
        }

        public void setStartTime(string startTime) {
            this.startTime = startTime;
        }

        public string getEndTime() {
            return this.endTime;
        }

        public void setEndTime(string endTime) {
            this.endTime = endTime; 
        }
    }
}
