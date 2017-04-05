using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    /** Interface is used for model mappers */
    interface IDataMapper {
        IModel map(MySqlDataReader reader);
    }
}
