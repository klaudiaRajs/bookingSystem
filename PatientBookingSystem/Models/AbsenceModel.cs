using System;

namespace PatientBookingSystem.Models {
    /** Class is a database model with all the setters and getters. Class implements IModel interface */
    public class AbsenceModel : IModel{

        public int absenceId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string reason { get; set; }
        public int staffId { get; set; }
        public string _startDate;
        public string _endDate;

        public string startDate {
            get { return _startDate; }
            set { _startDate = getNormalizedDate(value);  }
        }

        public string endDate {
            get { return _endDate;  }
            set { _endDate = getNormalizedDate(value); }
        }

        public DateTime getStartDateTime() {
            return DateTime.ParseExact(this.startDate + " " + this.startTime, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public DateTime getEndDateTime() {
            return DateTime.ParseExact(this.endDate + " " + this.endTime, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        /** Method normalizes format of the date (removes time) */
        private string getNormalizedDate(string date) {
            bool isDateTime = date.IndexOf(" ") >= 0;
            if (isDateTime) {
                date = date.Remove(date.IndexOf(" "));
            }
            return date;
        }
    }
}
