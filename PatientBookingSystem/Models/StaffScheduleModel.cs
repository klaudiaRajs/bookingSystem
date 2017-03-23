using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Models {
    class StaffScheduleModel : IModel{
        StaffModel staff;
        ScheduleModel schedule;
        int staffScheduleId;

        public void setStaffScheduleId(int id) {
            this.staffScheduleId = id;
        }

        public void setStaffMember(StaffModel member) {
            this.staff = member; 
        }

        public void setSchedule(ScheduleModel schedule) {
            this.schedule = schedule; 
        }

        public StaffModel getStaffMember() {
            return this.staff;
        }

        public ScheduleModel getSchedule() {
            return this.schedule;
        }

        public int getStaffScheduleId() {
            return this.staffScheduleId;
        }
    }
}
