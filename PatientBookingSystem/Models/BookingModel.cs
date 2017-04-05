using System;

namespace PatientBookingSystem.Models {
    /** Class is a database model of booking table - contains all the getters and setters */
    public class BookingModel : IModel{

        private int bookingId { get; set; } 
        private int confirmation { get; set; }
        private int attendance { get; set; }
        private int lackOfCancellation { get; set; }
        private string comment { get; set; }
        private int userId { get; set; }
        private int staffScheduleId { get; set; }
        private String startTime;
        private String endTime;
        private StaffModel staffMember;
        private ScheduleModel scheduleModel;
        private UserModel userModel { get; set; }

        public int getBookingId() {
            return this.bookingId;
        }

        public void setBookingId(int bookingId) {
            this.bookingId = bookingId; 
        }

        public UserModel getUserModel() {
            return this.userModel; 
        }

        public void setUserModel(UserModel user) {
            this.userModel = user; 
        }

        public ScheduleModel getScheduleModel() {
            return this.scheduleModel; 
        }

        public void setScheduleModel(ScheduleModel scheduleModel) {
            this.scheduleModel = scheduleModel; 
        }

        public StaffModel getStaffModel() {
            return this.staffMember; 
        } 

        public void setStaffMember(StaffModel staffModel) {
            this.staffMember = staffModel;
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

        public void setId(int id) {
            this.bookingId = id; 
        }

        public int getId() {
            return this.bookingId;
        }

        public void setConfirmation(int confirmation) {
            this.confirmation = confirmation;
        }

        public int getConfirmation() {
            return this.confirmation;
        }

        public void setAttendance(int attendance) {
            this.attendance = attendance;
        }
            
        public int getAttendance() {
            return this.attendance; 
        }

        public void setLackOfCancellation(int cancellation) {
            this.lackOfCancellation = cancellation;
        }

        public int getLackOfCancellation() {
            return this.lackOfCancellation; 
        }

        public void setComment(String comment) {
            this.comment = comment;
        }

        public String getComment() {
            return this.comment; 
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public int getUserId() {
            return this.userId; 
        }


        public void setStaffScheduleId(int staffScheduleId) {
            this.staffScheduleId = staffScheduleId;
        }

        public int getStaffScheduleId() {
            return this.staffScheduleId;
        }
            
    }
}
