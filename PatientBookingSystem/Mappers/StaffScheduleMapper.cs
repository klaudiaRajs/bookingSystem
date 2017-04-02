using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Class is responsible for mapping database fields to StaffScheduleModel */
    class StaffScheduleMapper : IDataMapper {

        /** Method returns a mapped (database to model) staffSchedule model */
        public IModel map(MySqlDataReader reader) {
            StaffModel staff = new StaffModel();
            ScheduleModel schedule = new ScheduleModel();
            StaffScheduleModel staffSchedule = new StaffScheduleModel(); 

            staff.setStaffId(reader.GetInt32("staffId"));
            staff.setFirstName(reader.GetString("firstName"));
            staff.setLastName(reader.GetString("lastName"));
            if (!reader.IsDBNull(6)) {
                staff.setPhoneNumber(reader.GetString("phoneNumber"));
            }
            staff.setStaffType(reader.GetString("staffType"));

            schedule.setScheduleId(reader.GetInt32("scheduleId"));
            schedule.setDate(reader.GetString("date"));
            schedule.setStartTime(reader.GetString("startTime"));
            schedule.setEndTime(reader.GetString("endTime"));

            staffSchedule.setStaffScheduleId(reader.GetInt32("staffScheduleId"));
            staffSchedule.setStaffMember(staff);
            staffSchedule.setSchedule(schedule);
            return staffSchedule; 
        }
    }
}
