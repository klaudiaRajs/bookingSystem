using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System.Collections.Generic;
using System;

namespace PatientBookingSystem.Controllers {
    /** Class is responsible for all the communication between presenters and staff repository */ 
    class StaffController {

        private StaffRepo repo; 

        public StaffController() {
            this.repo = new StaffRepo(); 
        }

        /** 
         * Method returns all the staff members 
         * 
         * @return list of all staff members
         */
        public List<IModel> getAllStaffMembers() {
            return repo.getAllStaffMembers();
        }

        /** 
         * Method returns staff type retrieved based on staff schedule id
         */
        public string getStaffTypeByStaffScheduleId(int staffScheduleId) {
            return repo.getStaffTypeBasedOnStaffScheduleId(staffScheduleId);
        }

        /** 
         * Method calls repository method for saving a staff member 
         * 
         * @param staffMember 
         * @return result of saving staff member
         */
        public bool addStaffMember(StaffModel staffMember) {
            return repo.addStaffMember(staffMember); 
        }
    }
}
