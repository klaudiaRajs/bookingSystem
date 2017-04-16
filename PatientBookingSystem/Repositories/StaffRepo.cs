using PatientBookingSystem.Mappers;
using PatientBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PatientBookingSystem.Repositories {
    /** Class is responsible for communicating rest of the system with pbs_staff table in the database */
    class StaffRepo : BaseRepo {
        
        private string table = "pbs_staff";

        /** 
         * Method returns staff model based on staff id 
         * 
         * @param id staff id 
         * @return staff model 
         */
        public StaffModel getStaffMemberById(int id) {
            string query = "SELECT * from " + table + " WHERE staffId = " + id;

            List<IModel> staffMembers = this.db.Query(query, new StaffMapper());
            if( staffMembers.Count == 0) {
                return null;
            }
            return (staffMembers.First() as StaffModel); 
        }

        /** 
         * Method returns staff type base on staff schedule id 
         * 
         * @param staffScheduleId
         * @return staff type
         */
        public string getStaffTypeBasedOnStaffScheduleId(int staffScheduleId) {
            string query = "SELECT * from scheduleview where staffScheduleId = " + staffScheduleId;
            List<IModel> staffMembers = this.db.Query(query, new StaffScheduleMapper());
            if( staffMembers.Count == 0) {
                return "Invalid";
            }
            return (staffMembers.First() as StaffScheduleModel).getStaffMember().getStaffType();
        }

        /** 
         * Saves staff model to the database and returns result (true/false) 
         * 
         * @param staffMember 
         * @return result of saving 
         */
        public bool addStaffMember(StaffModel staffMember) {
            string query = "INSERT INTO " + table + "(`firstName`, `lastName`, `phoneNumber`, `staffType`) VALUES( "
                + this.getStringInMySqlInsertableFormat(staffMember.getFirstName()) + ", "
                + this.getStringInMySqlInsertableFormat(staffMember.getLastName()) + ", "
                + (staffMember.getPhoneNumber() == "NULL" ? staffMember.getPhoneNumber() : this.getStringInMySqlInsertableFormat(staffMember.getPhoneNumber())) + ", "
                + this.getStringInMySqlInsertableFormat(staffMember.getStaffType()) + " )";
            return this.db.Execute(query);
        }

        /** 
         * Method return list of all staff members 
         * 
         * @return list of all staff members
         */
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
