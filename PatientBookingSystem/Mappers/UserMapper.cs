using MySql.Data.MySqlClient;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Class is responsible for mapping database fields to UserModel */
    class UserMapper : IDataMapper {

        /** Method returns a mapped (database to model) UserModel */
        public IModel map(MySqlDataReader record) {
            UserModel user = new UserModel();
            user.setId(record.GetInt32("id"));
            user.setFirstName(record.GetString("firstName"));
            user.setLastName(record.GetString("lastName"));
            user.setLogin(record.GetString("login"));
            user.setPassword(record.GetString("password"));
            user.setDOBs(record.GetString("DOB"));
            user.setDOBd(DateHelper.getDateTimeObjectFromString(record.GetString("DOB"))); 
            user.setEmailAddress(record.GetString("email"));
            if (!record.IsDBNull(6)) {
                user.setPhoneNumber(record.GetString("phoneNumber"));
            }
            if (!record.IsDBNull(8)) {
                user.setNiN(record.GetString("NiN"));
            }
            if (!record.IsDBNull(9)) {
                user.setAddress(record.GetString("address"));
            }
            if (!record.IsDBNull(11)) {
                user.setNotification(record.GetString("notification"));
            }
            if (!record.IsDBNull(12)) {
                user.setVerification(record.GetString("verification"));
            }
            if (!record.IsDBNull(13)) {
                user.setConfirmation(record.GetString("confirmation"));
            }
            user.setUserType(record.GetString("userType"));
            return user;
        }
    }
}
