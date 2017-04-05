using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Class is responsible for mapping database fields to BookingModel */
    class BookingMapper : IDataMapper {

        /** Method returns a mapped (database to model) BookingModel*/
        public IModel map(MySqlDataReader reader) {
            BookingModel booking = new BookingModel();
            UserModel user = new UserModel();
            StaffModel staff = new StaffModel();
            ScheduleModel schedule = new ScheduleModel();
            booking.setBookingId(reader.GetInt16("bookingId"));
            booking.setConfirmation(reader.GetInt16("confirmation"));
            booking.setAttendance(reader.GetInt16("attendance"));
                booking.setLackOfCancellation(reader.GetInt16("lackOfCancellation"));

            if (!reader.IsDBNull(14)) {
                booking.setComment(reader.GetString("comment"));
            } else {
                booking.setComment("");
            }
            booking.setStartTime(reader.GetString("startTime"));
            booking.setEndTime(reader.GetString("endTime"));
            if (reader.GetSchemaTable().Columns.Contains("patientId")) {
                booking.setUserId(reader.GetInt16("patientId"));
            }
            if (reader.GetSchemaTable().Columns.Contains("patientFirstName")) {
                user.setFirstName(reader.GetString("patientFirstName"));
            }
            user.setFirstName(reader.GetString("patientFirstName"));
            user.setLastName(reader.GetString("patientLastName"));
            booking.setUserModel(user);
            staff.setStaffId(reader.GetInt16("staffId"));
            staff.setFirstName(reader.GetString("staffFirstName"));
            staff.setLastName(reader.GetString("staffLastName"));
            staff.setStaffType(reader.GetString("staffType"));
            booking.setStaffMember(staff);
            schedule.setDate(reader.GetString("date"));
            booking.setScheduleModel(schedule);
            return booking;
        }
    }
}
