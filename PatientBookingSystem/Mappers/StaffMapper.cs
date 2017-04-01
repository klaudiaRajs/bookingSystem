using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    class StaffMapper : IDataMapper {
        public IModel map(MySqlDataReader reader) {
            StaffModel staffMember = new StaffModel();     
            staffMember.setStaffId(reader.GetInt16("staffId"));
            staffMember.setFirstName(reader.GetString("firstName"));
            staffMember.setLastName(reader.GetString("lastName"));
            if (!reader.IsDBNull(3)) {
                staffMember.setPhoneNumber(reader.GetString("phoneNumber"));
            }
            staffMember.setStaffType(reader.GetString("staffType"));
            return staffMember; 
        }
    }
}
