using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Class is responsible for mapping database fields to Absence model  */
    class AbsenceMapper : IDataMapper {
        
        /** 
         * Method returns a mapped (database to model) absence model 
         * 
         * @param reader MySqlDataReader 
         * @return Model implementing IModel interface - absence
         */
        public IModel map(MySqlDataReader reader) {
            AbsenceModel absence = new AbsenceModel();
            absence.absenceId = reader.GetInt16("absenceId");
            if (!reader.IsDBNull(1)) {
                absence.startTime = reader.GetString("startTime");
            }
            if (!reader.IsDBNull(2)) {
                absence.endTime = reader.GetString("endTime");
            }
            absence.reason = reader.GetString("reason");
            if (!reader.IsDBNull(4)) {
                absence.staffId = reader.GetInt16("staffId");
            }
            absence.startDate = Helpers.DateHelper.getDateTimeStringFromReader(reader, "startDate");
            absence.endDate = Helpers.DateHelper.getDateTimeStringFromReader(reader, "endDate");
            return absence;
        }
    }
}
