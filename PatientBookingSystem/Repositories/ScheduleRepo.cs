using PatientBookingSystem.Mappers;
using PatientBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace PatientBookingSystem.Repositories {
    /** Class is responsible for communication with schedule table and view */
    class ScheduleRepo : BaseRepo {

        string table = "pbs_schedule";

        /** Method returns all the available staff members with the times they're available */
        public List<IModel> getAvailableStaffMembersWithAvailabilityTimes(string day) {
            string query = "SELECT * FROM scheduleView WHERE date = " + '"' + day + '"';
            List<IModel> scheduleCollection = this.db.Query(query, new StaffScheduleMapper());
            return scheduleCollection;
        }

        /** Method saves schedule model to the database */
        public bool save(ScheduleModel schedule) {
            string query = "INSERT INTO " + table + " (`date`, `startTime`, `endTime`) VALUES ("
                + this.getStringInMySqlInsertableFormat(schedule.getDate()) + ", "
                + this.getStringInMySqlInsertableFormat(schedule.getStartTime()) + ", "
                + this.getStringInMySqlInsertableFormat(schedule.getEndTime()) + ")";
            return this.db.Execute(query);
        }

        /** Method saves staffSchedule to database */
        public bool saveStaffSchedule(int staffId, int scheduleId) {
            string query = "INSERT INTO pbs_staffschedule (`staffId`, `scheduleId`) VALUES (" 
                + staffId + ", " + scheduleId + ")";
            return this.db.Execute(query);
        }

        /** Method returns scheduleId based on other elements of schedule model */
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
