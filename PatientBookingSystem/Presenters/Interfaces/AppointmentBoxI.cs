using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Presenters.Interfaces {
    interface AppointmentBoxI {
        void getAppointmentBoxes();
        void setNumberOfAppointmentsPerDay(int morningAppointments, int afternoonAppointments); 
    }
}
