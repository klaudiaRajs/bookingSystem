using MySql.Data.MySqlClient;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    class UserMapper : IDataMapper {
        public IModel map(MySqlDataReader record) {
            UserModel user = new UserModel();
            user.setId(record.GetInt32("id"));
            user.setFirstName(record.GetString("firstName"));
            user.setLastName(record.GetString("lastName"));
            user.setLogin(record.GetString("login"));
            user.setPassword(record.GetString("password"));
            user.setDOBs(record.GetString("DOB"));
            user.setDOBd(DateHelper.getDateTimeObjectFromMySqlFormat(record.GetString("DOB"))); 
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
            user.setConfirmationMethod(record.GetString("confirmationMethod"));
            user.setUserType(record.GetString("userType"));
            return user;
        }
    }
}
