using System;

namespace PatientBookingSystem.Helpers {

    /** Attribute allowing printing content to console in different part of the system */
    [Serializable]

    /** Class is responsible for managing time ranges */
    public class TimeRange {
        TimeSpan start;
        TimeSpan end;

        public TimeRange(string from, string to) {
            setStart(from);
            setEnd(to);
        }

        public TimeRange(TimeSpan from, TimeSpan to) {
            this.start = from;
            this.end = to;
        }

        public void setStart(string start) {
            this.start = TimeSpan.Parse(start);
        }

        public void setEnd(string end) {
            this.end = TimeSpan.Parse(end);
        }

        /** Method checks if TimeSpan is in time range */
        public bool isInTimeRange(TimeSpan time) {
            return time >= this.start && time < this.end;
        }

        /** Method returns time range in a string format */
        public string getTimeRange() {
            return start.ToString().Substring(0,5) + " - " + end.ToString().Substring(0,5);
        }
    }
}
