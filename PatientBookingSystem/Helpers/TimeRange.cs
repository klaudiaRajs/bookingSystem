using System;

namespace PatientBookingSystem.Helpers {

    /** Attribute allowing printing content to console in different part of the system */
    [Serializable]

    /** Class is responsible for managing time ranges */
    public class TimeRange {
        TimeSpan start;
        TimeSpan end;

        /** 
         * Constructor - strings 
         * 
         * @param from start time 
         * @param to end time
         */
        public TimeRange(string from, string to) {
            setStart(from);
            setEnd(to);
        }

        /** 
         * Constructor overload - TimeSpans
         * 
         * @param from startTime 
         * @param to end time 
         */
        public TimeRange(TimeSpan from, TimeSpan to) {
            this.start = from;
            this.end = to;
        }
        
        /** 
         * Method parses the string time into timespan 
         * 
         * @param start
         */
        public void setStart(string start) {
            this.start = TimeSpan.Parse(start);
        }

        /** 
         * Method parses the string time into timespan 
         * 
         * @param end
         */
        public void setEnd(string end) {
            this.end = TimeSpan.Parse(end);
        }

        /** 
         * Method checks if TimeSpan is in time range
         * 
         * @param time
         * @return information on whether time is wihitn the range 
         */
        public bool isInTimeRange(TimeSpan time) {
            return time >= this.start && time < this.end;
        }

        /** 
         * Method returns time range in a string format 
         * 
         * @return time range 
         */
        public string getTimeRange() {
            return start.ToString().Substring(0,5) + " - " + end.ToString().Substring(0,5);
        }
    }
}
