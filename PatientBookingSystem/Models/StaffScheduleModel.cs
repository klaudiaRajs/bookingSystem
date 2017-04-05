namespace PatientBookingSystem.Models {
    /** Class is a database model of staffSchedule table - contains all the getters and setters */
    public class StaffScheduleModel : IModel{

        private StaffModel staff;
        private ScheduleModel schedule;
        private int staffScheduleId;

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
