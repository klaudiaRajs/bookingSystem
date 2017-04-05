﻿using System;

namespace PatientBookingSystem.Helpers {
    /** Class is responsible for converting dates into different string formats */
    public static class DateHelper {

        /** Method translates a date that is not formatted for MySQL into MySQL format */
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

        /** Method generates DateTime object based on contents of date string. Method can detect 20.05.2017 format and 2017-05-02 format */
        public static DateTime getDateTimeObjectFromString(string date) {
            string day = "";
            string month = "";
            string year = "";

            if (date.IndexOf(".") != -1) {
                day = date.Substring(0, 2);
                month = date.Substring(3, 2);
                year = date.Substring(6, 4);
            } else if (date.IndexOf("-") != -1) {
                year = date.Substring(0, 4);
                month = date.Substring(5, 2);
                day = date.Substring(8, 2);
            } else if (date.IndexOf('\\') != -1) {
                day = date.Substring(0, 2);
                month = date.Substring(3, 2);
                year = date.Substring(6, 4);
            } else if (date.IndexOf("/") != -1) {
                day = date.Substring(0, 2);
                month = date.Substring(3, 2);
                year = date.Substring(6, 4);
            }

            DateTime dateObject = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            return dateObject;
        }

        /** Method returns the last day of a given month (DateTime object) */
        public static DateTime convertToLastDayOfMonth(DateTime date) {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
