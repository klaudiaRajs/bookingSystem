using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Mappers {
    interface IDataMapper {
        IModel map(MySqlDataReader reader);
    }
}
