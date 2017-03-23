using MySql.Data.MySqlClient;
using PatientBookingSystem.Mappers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Repositories {
    class ScheduleRepo : BaseRepo {

        string table = "pbs_schedule";

        public List<IModel> getAvailableStaffMembersWithAvailabilityTimes(string day) {
            string query = "SELECT * FROM scheduleView WHERE date = " + '"' + day + '"';
            List<IModel> scheduleCollection = this.db.Query(query, new StaffScheduleMapper());
            return scheduleCollection;
        }

        public bool save(ScheduleModel schedule) {
            string query = "INSERT INTO " + table + " (`date`, `startTime`, `endTime`) VALUES ("
                + this.getStringInMySqlInsertableFormat(schedule.getDate()) + ", "
                + this.getStringInMySqlInsertableFormat(schedule.getStartTime()) + ", "
                + this.getStringInMySqlInsertableFormat(schedule.getEndTime()) + ")";
            return this.db.Execute(query);
        }

        public int getScheduleId(ScheduleModel schedule) {
            string query = "SELECT * from " + table + " WHERE date= "
                + this.getStringInMySqlInsertableFormat(schedule.getDate())
                + " AND startTime = " + this.getStringInMySqlInsertableFormat(schedule.getStartTime())
                + " AND endTime = " + this.getStringInMySqlInsertableFormat(schedule.getEndTime());
            List<IModel> result = this.db.Query(query, new ScheduleMapper());
            return (result.First() as ScheduleModel).getScheduleId();
        }
    }
}
