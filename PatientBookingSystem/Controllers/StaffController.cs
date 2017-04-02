using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System.Collections.Generic;

namespace PatientBookingSystem.Controllers {
    /** Class is responsible for all the communication between presenters and staff repository */ 
    class StaffController {

        StaffRepo repo; 

        public StaffController() {
            this.repo = new StaffRepo(); 
        }

        /** Method returns all the staff members */
        public List<IModel> getAllStaffMembers() {
            return repo.getAllStaffMembers();
        }

        /** Method calls repository method for saving a staff member */ 
        public bool addStaffMember(StaffModel staffMember) {
            return repo.addStaffMember(staffMember); 
        }
    }
}
