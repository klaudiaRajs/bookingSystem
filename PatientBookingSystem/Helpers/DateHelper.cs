using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    public static class DateHelper {

        public static string getDateInMySqlFormat(string nonInFormatDate) {
            if( nonInFormatDate.IndexOf(".") == 4 
                || nonInFormatDate.IndexOf("-") == 4
                || nonInFormatDate.IndexOf("/") == 4) {
                // 
                return nonInFormatDate;
            }
            else if (nonInFormatDate.IndexOf(".") == 2
                || nonInFormatDate.IndexOf("-") == 2
                || nonInFormatDate.IndexOf(".") == 2) {
                string day = nonInFormatDate.Substring(0,2);
                string month = nonInFormatDate.Substring(3, 2); 
                string year = nonInFormatDate.Substring(6);
                string date = year + "-" + month + "-" + day;
                return date;
            }
            return null;
        }

        public static DateTime getDateTimeObjectFromMySqlFormat(string date) {
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 5);

            DateTime dateObject = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            return dateObject;
        }

        public static DateTime convertToLastDayOfMonth(DateTime date) {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
