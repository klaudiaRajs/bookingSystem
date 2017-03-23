using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    class AbsenceMapper : IDataMapper {
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
            absence.startDate = reader.GetString("startDate");
            absence.endDate = reader.GetString("endDate");
            return absence;
        }
    }
}
