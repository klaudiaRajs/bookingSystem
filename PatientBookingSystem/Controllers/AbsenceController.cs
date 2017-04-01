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

        /** Absence repository */
        private AbsenceRepo repo;

        /**
         * Initialization of absence repository  
         */
        public AbsenceController() {
            this.repo = new AbsenceRepo();
        }


        /** 
         * Public method for saving an absence
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
         * Method validates if all the data is valid for saving
         */
        public List<string> isDataValid(DateTimePicker startDatePicker, DateTimePicker endDatePicker, DateTimePicker startTimePicker, DateTimePicker endTimePicker, List<string> invalidFieldsList, ComboBox allTheDoctors = null) {
            List<string> invalidFields = invalidFieldsList;
            bool result = true;
            if (allTheDoctors != null) {
                if ((int)allTheDoctors.SelectedValue <= 0) {
                    invalidFields.Add("doctor's name");
                    result = false;
                }
            }

            if (startDatePicker.Value < DateTime.Today) {
                invalidFields.Add("start date");
                result = false;
            }

            if (endDatePicker.Enabled && endDatePicker.Value.Date < startDatePicker.Value.Date) {
                invalidFields.Add("end date");
                result = false;
            }

            if (!endDatePicker.Enabled && startTimePicker.Value >= endTimePicker.Value) {
                invalidFields.Add("time fields");
                result = false;
            }

            if (!result) {
                return invalidFields;
            }

            return null;
        }

        /** 
         * Methods saves the absence if correct data provided
         */
        private bool saveAbsence(AbsenceModel absence) {
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
                return this.repo.saveAbsence(absence);
            }
            return false;
        }
    }
}
