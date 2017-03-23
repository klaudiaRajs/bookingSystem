using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    class ScheduleMapper : IDataMapper {
        public IModel map(MySqlDataReader reader) {
            //int staffScheduleId = reader.GetInt32("staffScheduleId");
            ScheduleModel schedule = new ScheduleModel();
            //StaffModel staff = new StaffModel();
            schedule.setScheduleId(reader.GetInt32("scheduleId"));
            schedule.setDate(reader.GetString("date"));
            schedule.setStartTime(reader.GetString("startTime"));
            schedule.setEndTime(reader.GetString("endTime"));
            //staff.setFirstName(reader.GetString("firstName"));
            //staff.setLastName(reader.GetString("lastName"));
            //staff.setStaffType(reader.GetString("staffType"));
            //staff.setStaffId(reader.GetInt16("staffId"));
            //schedule.setStaffMember(staff);
            return schedule;
        }
    }
}
