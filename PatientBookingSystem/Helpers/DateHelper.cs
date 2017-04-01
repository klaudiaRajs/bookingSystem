using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Helpers {
    public static class DateHelper {

        public static string getDateInMySqlFormat(string nonInFormatDate) {
            if (nonInFormatDate.IndexOf(".") == 4
                || nonInFormatDate.IndexOf("-") == 4
                || nonInFormatDate.IndexOf("/") == 4) {
                return nonInFormatDate;
            } else if (nonInFormatDate.IndexOf(".") == 2
                  || nonInFormatDate.IndexOf("-") == 2
                  || nonInFormatDate.IndexOf(".") == 2) {
                string day = nonInFormatDate.Substring(0, 2);
                string month = nonInFormatDate.Substring(3, 2);
                string year = nonInFormatDate.Substring(6);
                string date = year + "-" + month + "-" + day;
                return date;
            }
            return null;
        }

        /**
         *  Method generates DateTime object based on contents of date string. Method can detect 20.05.2017 format and 2017-05-02 format
         */
        public static DateTime getDateTimeObjectFromString(string date) {
            string day = "";
            string month = "";
            string year = "";

            if (date.IndexOf(".") != -1) {
                day = date.Substring(0, 2);
                month = date.Substring(3, 2);
                year = date.Substring(6, 5);
            } else if (date.IndexOf("-") != -1) {
                year = date.Substring(0, 4);
                month = date.Substring(5, 2);
                day = date.Substring(8, 2);
            }

            DateTime dateObject = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            return dateObject;
        }

        public static DateTime convertToLastDayOfMonth(DateTime date) {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
