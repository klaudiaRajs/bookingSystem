using System;

namespace PatientBookingSystem.Models {
    class BookingModel : IModel{
        int bookingId { get; set; } 
        int confirmation { get; set; }
        int attendance { get; set; }
        int lackOfCancellation { get; set; }
        String comment { get; set; }
        int userId { get; set; }
        int staffScheduleId { get; set; }
        String startTime;
        String endTime;
        StaffModel staffMember;
        ScheduleModel scheduleModel;
        UserModel userModel { get; set; }

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
