using PatientBookingSystem.Mappers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace PatientBookingSystem.Repositories {
    /** Class is responsible for retrieving data from the absence table */
    class AbsenceRepo : BaseRepo {

        string table = "pbs_absence";

        /** Method returns list of absences per day */
        public List<IModel> getAbsencesPerDate(string date) {
            string query = "SELECT * from pbs_absence WHERE pbs_absence.startDate <= " + '"' + date + '"' + " AND pbs_absence.endDate >= " + '"' + date + '"';
            List<IModel> absences = this.db.Query(query, new AbsenceMapper());
            return absences;       
        }

        /** Method saves absence model to absence table in the database */
        public bool saveAbsence(AbsenceModel absence) {
            string query = "INSERT INTO " + table + " (`startTime`, `endTime`, `reason`, `staffId`, `startDate`, `endDate`) " + 
                " VALUES ( " + (absence.startTime != "NULL" ? this.getStringInMySqlInsertableFormat(absence.startTime) : absence.startTime) + ", "
                + (absence.endTime != "NULL" ? this.getStringInMySqlInsertableFormat(absence.endTime) : absence.endTime)+ ", " 
                + (absence.reason != "NULL" ? this.getStringInMySqlInsertableFormat(absence.reason) : absence.reason) + ", "
                + (absence.staffId == -1 ? "NULL" : absence.staffId.ToString()) + ", "
                + this.getStringInMySqlInsertableFormat(absence.startDate) + ", "
                + (absence.endDate != "NULL" ? this.getStringInMySqlInsertableFormat(absence.endDate) : absence.endDate) + " )";
            return this.db.Execute(query);

        }

        /** Method returns list of absences per day, where the absence is markes as full surgery absence */
        public List<IModel> getSurgeryAbsencesPerDate(string date) {
            string query = "SELECT * from pbs_absence WHERE pbs_absence.startDate <= " + '"' + date + '"' + " AND pbs_absence.endDate >= " + '"'
                + date + '"' + " AND staffId IS NULL";

            List<IModel> absences = this.db.Query(query, new AbsenceMapper());
            if( absences.Count == 0) {
                return null;
            }
            return absences; 
        }
    }
}
