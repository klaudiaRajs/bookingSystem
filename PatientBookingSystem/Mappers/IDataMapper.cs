using MySql.Data.MySqlClient;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Mappers {
    interface IDataMapper {
        IModel map(MySqlDataReader reader);
    }
}
