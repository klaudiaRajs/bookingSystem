using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DateTime getStartDateTime() {
            return DateTime.ParseExact(this.date + " " + this.startTime, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void setStartTime(String startTime) {
            this.startTime = startTime;
        }

        public String getEndTime() {
            return this.endTime;
        }

        public DateTime getEndDateTime() {
            return DateTime.ParseExact(this.date + " " + this.endTime, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void setEndTime(String endTime) {
            this.endTime = endTime; 
        }
    }
}
