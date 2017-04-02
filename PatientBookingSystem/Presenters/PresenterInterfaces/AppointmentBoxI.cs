﻿namespace PatientBookingSystem.Presenters.Interfaces {
    /** Interface to allow communication between single day schedule and different presenters */
    interface AppointmentBoxI {
        void getAppointmentBoxes();
        void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments); 
    }
}
