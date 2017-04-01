namespace PatientBookingSystem.Presenters.Interfaces {
    interface AppointmentBoxI {
        void getAppointmentBoxes();
        void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments); 
    }
}
