using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Class is responsible for mapping database fields to ScheduleModel */
    class ScheduleMapper : IDataMapper {

        /** Method returns a mapped (database to model) ScheduleModel */
        public IModel map(MySqlDataReader reader) {
            ScheduleModel schedule = new ScheduleModel();
            schedule.setScheduleId(reader.GetInt32("scheduleId"));
            schedule.setDate(reader.GetString("date"));
            schedule.setStartTime(reader.GetString("startTime"));
            schedule.setEndTime(reader.GetString("endTime"));
            return schedule;
        }
    }
}
