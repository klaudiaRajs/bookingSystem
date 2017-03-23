using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientBookingSystem.Controllers {
    class AbsenceController {
        AbsenceRepo repo;

        public AbsenceController() {
            this.repo = new AbsenceRepo();
        }

        public bool saveAbsence(AbsenceModel absence) {
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
            return this.repo.saveAbsence(absence);
        }


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

        public List<string> isDataValid(DateTimePicker startDatePicker, DateTimePicker endDatePicker, DateTimePicker startTimePicker, DateTimePicker endTimePicker, List<string> invalidFields, ComboBox allTheDoctors = null  ) {
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
            if( !result) {
                return invalidFields;
            }
            return null;
        }
    }
}
