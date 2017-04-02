using PatientBookingSystem.Mappers;
using PatientBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace PatientBookingSystem.Repositories {
    /** Class is responsible for communicating rest of the system with pbs_staff table in the database */
    class StaffRepo : BaseRepo {
        
        string table = "pbs_staff";

        /** Returns staff model based on staff id */
        internal StaffModel getStaffMemberById(int id) {
            string query = "SELECT * from " + table + " WHERE staffId = " + id;

            List<IModel> staffMembers = this.db.Query(query, new StaffMapper());
            if( staffMembers.Count == 0) {
                return null;
            }
            return (staffMembers.First() as StaffModel); 
        }

        /** Saves staff model to the database and returns result (true/false) */
        internal bool addStaffMember(StaffModel staffMember) {
            string query = "INSERT INTO " + table + "(`firstName`, `lastName`, `phoneNumber`, `staffType`) VALUES( "
                + this.getStringInMySqlInsertableFormat(staffMember.getFirstName()) + ", "
                + this.getStringInMySqlInsertableFormat(staffMember.getLastName()) + ", "
                + (staffMember.getPhoneNumber() == "NULL" ? staffMember.getPhoneNumber() : this.getStringInMySqlInsertableFormat(staffMember.getPhoneNumber())) + ", "
                + this.getStringInMySqlInsertableFormat(staffMember.getStaffType()) + " )";
            return this.db.Execute(query);
        }

        /** Return list of all staff members */
        internal List<IModel> getAllStaffMembers() {
            string query = "SELECT * from " + table; 
            List<IModel> staffMembers = this.db.Query(query, new StaffMapper()); 
            if( staffMembers.Count == 0) {
                return null;
            }
            return staffMembers; 
        }
    }
}
