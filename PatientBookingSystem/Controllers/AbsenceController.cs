using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientBookingSystem.Controllers {
    /** 
     * Class is a communicator between absence repository and presenters 
     */
    class AbsenceController {
        
        /** 
         * Public method for saving an absence 
         * 
         * @param absence absence model 
         * @return result of saving
         */
        public bool save(AbsenceModel absence) {
            bool result;
            if (absence.staffId != 0) {
                try {
                    return result = this.saveAbsence(absence);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
            }
            return false;
        }

        /** 
         * Method initiates process of validating if all the data is valid for saving 
         * 
         * @param startDatePicker 
         */
        public List<string> isDataValid(DateTimePicker startDatePicker, DateTimePicker endDatePicker, DateTimePicker startTimePicker, DateTimePicker endTimePicker, List<string> invalidFieldsList, ComboBox allTheDoctors = null) {
            return Validator.validateAbsenceParameters(startDatePicker, endDatePicker, startTimePicker, endTimePicker, invalidFieldsList, allTheDoctors);         
        }

        /** 
         * Methods saves the absence if correct data provided 
         * 
         * @param abcence Absence model
         * @return result of saving
         */
        private bool saveAbsence(AbsenceModel absence) {
            AbsenceRepo repo = new AbsenceRepo(); 
            if (String.IsNullOrEmpty(absence.startTime)) {
                absence.startTime = "NULL";
            }
            if (String.IsNullOrEmpty(absence.endTime)) {
                absence.endTime = "NULL";
            }
            if (String.IsNullOrEmpty(absence.endTime)) {
                absence.endTime = "NULL";
            }
            if (String.IsNullOrEmpty(absence.reason)) {
                absence.reason = "NULL";
            }
            if (String.IsNullOrEmpty(absence.endDate)) {
                absence.endDate = "NULL";
            }
            if (Validator.validateAbsenceForSaving(absence).Count == 0) {
                return repo.saveAbsence(absence);
            }
            return false;
        }
    }
}
