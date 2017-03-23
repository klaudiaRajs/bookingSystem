using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;

namespace PatientBookingSystem.Controllers {
    class ScheduleController {
        /*@TODO move it from here*/
        public enum slotStatus { Available, Booked, NotAvailable };

        BookingRepo bookingRepo = new BookingRepo();
        ScheduleRepo scheduleRepo = new ScheduleRepo();
        AbsenceRepo absenceRepo = new AbsenceRepo();
        Dictionary<int, List<TimeRange>> absences;
        Dictionary<int, List<TimeRange>> bookings;
        List<IModel> scheduleMap;

        string date;

        public ScheduleController(string date = null) {
            this.date = date;
            refresh();
        }

        public List<bool> saveStaffSchedules(int staffId, List<int> scheduleIdList) {
            List<bool> results = new List<bool>(); 
            if (staffId != 0 && scheduleIdList.Count != 0) {
                foreach (int scheduleId in scheduleIdList) {
                    if( scheduleRepo.saveStaffSchedule(staffId, scheduleId)) {
                        results.Add(true);
                    }
                }
            }
            return results;
        }

        public bool saveSchedule(ScheduleModel schedule) {
            if (schedule.getDate() != null && schedule.getStartTime() != null && schedule.getEndTime() != null) {
                return scheduleRepo.save(schedule);
            }
            return false;
        }

        public slotStatus getSlotStatus(TimeSpan time, int staffId) {
            if (isAbsent(date, time, staffId)) {
                return slotStatus.NotAvailable;
            }

            if (isBooked(date, time, staffId)) {
                return slotStatus.Booked;
            }

            List<IModel> scheduleMap = getScheduleMap();
            foreach (StaffScheduleModel staffSchedule in scheduleMap) {
                if (staffSchedule.getStaffMember().getStaffId() != staffId) {
                    continue;
                }
                TimeSpan memberWorkingTimeTo = TimeSpan.Parse(staffSchedule.getSchedule().getEndTime());
                TimeSpan memberSlotStartsFrom = TimeSpan.Parse(staffSchedule.getSchedule().getStartTime());
                TimeRange scheduleFromTo = new TimeRange(memberSlotStartsFrom, memberWorkingTimeTo);
                if (scheduleFromTo.isInTimeRange(time)) {
                    return slotStatus.Available;
                }
            }
            return slotStatus.NotAvailable;
        }

        public int getStaffScheduleId(TimeSpan time, int staffId) {
            List<IModel> scheduleMap = getScheduleMap();
            foreach (StaffScheduleModel staffSchedule in scheduleMap) {
                if (staffSchedule.getStaffMember().getStaffId() != staffId) {
                    continue;
                }
                TimeSpan memberWorkingTimeTo = TimeSpan.Parse(staffSchedule.getSchedule().getEndTime());
                TimeSpan memberSlotStartsFrom = TimeSpan.Parse(staffSchedule.getSchedule().getStartTime());
                TimeRange scheduleFromTo = new TimeRange(memberSlotStartsFrom, memberWorkingTimeTo);
                if (scheduleFromTo.isInTimeRange(time)) {
                    return staffSchedule.getStaffScheduleId();
                }
            }
            return 0;
        }

        public Dictionary<int, string> getAllAvailableDoctorsPerDate() {
            Dictionary<int, string> doctors = new Dictionary<int, string>();

            List<IModel> scheduleMap = scheduleRepo.getAvailableStaffMembersWithAvailabilityTimes(date);
            foreach (StaffScheduleModel schedule in scheduleMap) {
                int staffId = schedule.getStaffMember().getStaffId();
                if (!doctors.ContainsKey(staffId)) {
                    doctors.Add(staffId, schedule.getStaffMember().getFullStaffName());
                }
            }
            return doctors;
        }

        public void refresh() {
            absences = getListOfAllAbsencesPerDate(date);
            bookings = getListOfBookingsPerStaffMemberPerDate(date);
            scheduleMap = scheduleRepo.getAvailableStaffMembersWithAvailabilityTimes(date);
        }

        private bool isAbsent(string date, TimeSpan time, int staffId) {
            //ObjectCache cache = MemoryCache.Default;
            //Dictionary<int, List<TimeRange>> absences = cache["absences_" + date] as Dictionary<int, List<TimeRange>>;
            //if (absences == null) {
            //    absences = getListOfAllAbsencesPerDate(date);
            //    CacheItemPolicy policy = new CacheItemPolicy();
            //    cache.Set("absences_" + date, absences, policy);
            //}
            return absences.ContainsKey(staffId) && isInAnyTimeRange(absences[staffId], time);
        }

        public int getScheduleId(ScheduleModel schedule) {
            return scheduleRepo.getScheduleId(schedule);
        }

        private bool isBooked(string date, TimeSpan time, int staffId) {
            //ObjectCache cache = MemoryCache.Default;
            //Dictionary<int, List<TimeRange>> bookings = cache["bookings_" + date] as Dictionary<int, List<TimeRange>>;
            //if (bookings == null) {
            //    bookings = getListOfBookingsPerStaffMemberPerDate(date);
            //    CacheItemPolicy policy = new CacheItemPolicy();
            //    cache.Set("bookings_" + date, bookings, policy);
            //}
            return bookings.ContainsKey(staffId) && isInAnyTimeRange(bookings[staffId], time);
        }

        public List<IModel> getScheduleMap() {
            //ObjectCache cache = MemoryCache.Default;
            //Dictionary<int, List<ScheduleModel>> scheduleMap = cache["scheduleMap_" + date] as Dictionary<int, List<ScheduleModel>>;
            //if (scheduleMap == null) {
            //    scheduleMap = scheduleRepo.getAvailableStaffMembersWithAvailabilityTimes(date);
            //    CacheItemPolicy policy = new CacheItemPolicy();
            //    cache.Set("scheduleMap_" + date, scheduleMap, policy);
            //}
            //scheduleMap = scheduleRepo.getAvailableStaffMembersWithAvailabilityTimes(date);
            return scheduleMap;
        }

        private Dictionary<int, List<TimeRange>> getListOfAllAbsencesPerDate(string date) {
            Dictionary<int, List<TimeRange>> absencesPerMember = new Dictionary<int, List<TimeRange>>();

            List<IModel> registeredAbsences = absenceRepo.getAbsencesPerDate(date);
            if (registeredAbsences != null) {
                foreach (AbsenceModel absence in registeredAbsences) {
                    int staffId = absence.staffId;
                    if (!absencesPerMember.ContainsKey(staffId)) {
                        absencesPerMember.Add(staffId, new List<TimeRange>());
                    }
                    absencesPerMember[staffId].Add(new TimeRange(absence.startTime, absence.endTime));
                }
            } else {
                //@TODO add some handling here - what would happen if there are no absences ?? 
            }
            return absencesPerMember;
        }

        private Dictionary<int, List<TimeRange>> getListOfBookingsPerStaffMemberPerDate(string date) {
            Dictionary<int, List<TimeRange>> bookingsPerMember = new Dictionary<int, List<TimeRange>>();

            List<IModel> bookedAppointments = bookingRepo.getBookedAppointmentsPerDate(date);
            if (bookedAppointments.Count > 0 || bookedAppointments != null) {
                foreach (BookingModel appointment in bookedAppointments) {
                    int staffId = appointment.getStaffModel().getStaffId();
                    if (!bookingsPerMember.ContainsKey(staffId)) {
                        bookingsPerMember.Add(staffId, new List<TimeRange>());
                    }
                    bookingsPerMember[staffId].Add(new TimeRange(appointment.getStartTime(), appointment.getEndTime()));
                }
                return bookingsPerMember;
            }
            return null;
        }

        private bool isInAnyTimeRange(List<TimeRange> list, TimeSpan time) {
            foreach (TimeRange timeRange in list) {
                if (timeRange.isInTimeRange(time)) {
                    return true;
                }
            }
            return false;
        }

        private void debugPrint(Dictionary<int, List<TimeRange>> appointmentList) {
            Console.WriteLine("----------------------------------");
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(appointmentList.GetType());
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            serializer.WriteObject(ms, appointmentList);
            string json = Encoding.Default.GetString(ms.ToArray());
            Console.WriteLine(json);
            Console.WriteLine("----------------------------------");
        }
    }
}
