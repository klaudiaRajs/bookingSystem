using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    [Serializable]
    class TimeRange {
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

        public bool isInTimeRange(TimeSpan time) {
            return time >= this.start && time < this.end;
        }

        public string getTimeRange() {
            return start.ToString().Substring(0,5) + " - " + end.ToString().Substring(0,5);
        }
    }
}
