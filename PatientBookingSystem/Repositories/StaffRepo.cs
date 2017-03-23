using MySql.Data.MySqlClient;
using PatientBookingSystem.Mappers;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Repositories {
    class StaffRepo : BaseRepo {

        String table = "pbs_staff";

        public StaffModel getStaffMemberById(int id) {
            string query = "SELECT * from " + table + " WHERE staffId = " + id;

            List<IModel> staffMembers = this.db.Query(query, new StaffMapper());
            if( staffMembers.Count == 0) {
                return null;
            }
            return (staffMembers.First() as StaffModel); 
        }

        internal bool addStaffMember(StaffModel staffMember) {
            string query = "INSERT INTO " + table + "(`firstName`, `lastName`, `phoneNumber`, `staffType`) VALUES( "
                + this.getStringInMySqlInsertableFormat(staffMember.getFirstName()) + ", "
                + this.getStringInMySqlInsertableFormat(staffMember.getLastName()) + ", "
                + (staffMember.getPhoneNumber() == "NULL" ? staffMember.getPhoneNumber() : this.getStringInMySqlInsertableFormat(staffMember.getPhoneNumber())) + ", "
                + this.getStringInMySqlInsertableFormat(staffMember.getStaffType()) + " )";
            return this.db.Execute(query);
        }

        public List<IModel> getAllStaffMembers() {
            string query = "SELECT * from " + table; 
            List<IModel> staffMembers = this.db.Query(query, new StaffMapper()); 
            if( staffMembers.Count == 0) {
                return null;
            }
            return staffMembers; 
        }
    }
}
