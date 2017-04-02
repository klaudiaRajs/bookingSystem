using System;

namespace PatientBookingSystem.Models {
    class ScheduleModel : IModel {
        int scheduleId;
        String date;
        String startTime;
        String endTime;
        StaffModel staffMember; 

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

        public String getDate() {
            return this.date; 
        }

        /** Method sets model's date and if required deletes time part from date string */
        public void setDate(String date) {
            bool isDateTime = date.IndexOf(" ") >= 0;
            if (isDateTime) {
                date = date.Remove(date.IndexOf(" "));
            }
            this.date = date; 
        }

        public String getStartTime() {
            return this.startTime; 
        }

        public void setStartTime(String startTime) {
            this.startTime = startTime;
        }

        public String getEndTime() {
            return this.endTime;
        }

        public void setEndTime(String endTime) {
            this.endTime = endTime; 
        }
    }
}
