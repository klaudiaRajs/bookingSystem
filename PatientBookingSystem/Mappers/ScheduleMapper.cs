using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    class ScheduleMapper : IDataMapper {
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
