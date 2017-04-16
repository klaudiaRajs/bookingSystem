using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Class is responsible for mapping database fields to StaffModel */
    class StaffMapper : IDataMapper {

        /** 
         * Method returns a mapped (database to model) StaffModel
         * @param reader MySqlDataReader 
         * @return Model implementing IModel interface - staff
         */
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
