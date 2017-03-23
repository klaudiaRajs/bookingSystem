using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Controllers {
    class StaffController {
        StaffRepo repo; 

        public StaffController() {
            this.repo = new StaffRepo(); 
        }

        public List<IModel> getAllStaffMembers() {
            return repo.getAllStaffMembers();
        }

        public bool addStaffMember(StaffModel staffMember) {
            return repo.addStaffMember(staffMember); 
        }
    }
}
