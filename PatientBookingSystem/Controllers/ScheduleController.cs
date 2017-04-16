using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBookingSystem.Controllers {
    /** 
     * Class is responsible for all the actions requiring communication between presenters and repositories 
     */
    class ScheduleController {

        /** All the available slot statuses */
        public enum slotStatus { Available, Booked, NotAvailable };

        private BookingRepo bookingRepo = new BookingRepo();
        private ScheduleRepo scheduleRepo = new ScheduleRepo();
        private AbsenceRepo absenceRepo = new AbsenceRepo();

        private Dictionary<int, List<TimeRange>> absences;
        private Dictionary<int, List<TimeRange>> bookings;

        private List<IModel> scheduleMap;

        private string date;

        /** 
         * Contructor calls on method refreshing data for generating a schedule 
         * 
         * @param date optional date
         */
        public ScheduleController(string date = null) {
            this.date = date;
            refresh();
        }

        /** 
         * Returns scheduleId based on other schedule information 
         * 
         * @param schedule scheduleModel
         * @return scheduleId 
         */
        public int getScheduleIdBasedOnOtherScheduleInformation(ScheduleModel schedule) {
            return scheduleRepo.getScheduleId(schedule);
        }

        /** 
         * Method calls on relevant methods to create staff schedule database entry 
         * 
         * @param staffId 
         * @param scheduleIdList list of schedule ids 
         * @return result of saving every staffSchedule links 
         */
        public List<bool> saveStaffSchedules(int staffId, List<int> scheduleIdList) {
            bool validation = Validator.validateStaffSchedule(staffId, scheduleIdList);
            List<bool> errors = new List<bool>();
            if (validation) {
                foreach (int scheduleId in scheduleIdList) {
                    if (!scheduleRepo.saveStaffSchedule(staffId, scheduleId)) {
                        errors.Add(true);
                    }
                }
            }
            return errors;
        }

        /** 
         * Method calls on relevant repository methods to save schedule entry 
         * 
         * @param schedule scheduleModel 
         * @return result of saving schedule
         */
        public bool saveSchedule(ScheduleModel schedule) {
            if (schedule.getDate() != null && schedule.getStartTime() != null && schedule.getEndTime() != null) {
                return scheduleRepo.save(schedule);
            }
            return false;
        }

        /** 
         * Method returns slot status for given time and staff member 
         * 
         * @param time 
         * @param staffId 
         * @return slot status 
         */
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

        /** 
         * Method returns scheduleId based on time and staff member 
         * 
         * @param time
         * @param staffId 
         * @return staffScheduleId representation of schedule per staff member
         */
        internal int getStaffScheduleId(TimeSpan time, int staffId) {
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

        /** 
         * Method returns a list of staffschedule models 
         * 
         * @return dictionary connecting staff member id with their name
         */
        internal Dictionary<int, string> getAllAvailableStaffMembersPerDate() {
            Dictionary<int, string> staffMembers = new Dictionary<int, string>();

            List<IModel> scheduleMap = scheduleRepo.getAvailableStaffMembersWithAvailabilityTimes(date);
            foreach (StaffScheduleModel schedule in scheduleMap) {
                int staffId = schedule.getStaffMember().getStaffId();
                if (!staffMembers.ContainsKey(staffId)) {
                    staffMembers.Add(staffId, schedule.getStaffMember().getFullStaffName());
                }
            }
            return staffMembers;
        }

        /** 
         * Methods refreshes data required for building a schedule 
         */
        internal void refresh() {
            absences = getListOfAllAbsencesPerDate(date);
            bookings = getListOfBookingsPerStaffMemberPerDate(date);
            scheduleMap = scheduleRepo.getAvailableStaffMembersWithAvailabilityTimes(date);
        }

        /** 
         * Method checks if staff is absent on given datetime 
         * 
         * @param date
         * @param time
         * @param staffId
         * @return bool represing absence of the staff member
         */
        private bool isAbsent(string date, TimeSpan time, int staffId) {
            return absences.ContainsKey(staffId) && isInAnyTimeRange(absences[staffId], time);
        }

        /** 
         * Method checked if a slot is already booked 
         * 
         * @param date
         * @param time
         * @param staffId 
         * @return appointment status (booked/available)
         */
        private bool isBooked(string date, TimeSpan time, int staffId) {
            return bookings.ContainsKey(staffId) && isInAnyTimeRange(bookings[staffId], time);
        }

        /** 
         * Method returns list of staffschedule models 
         * 
         * @return schedule map
         */
        public List<IModel> getScheduleMap() {
            return scheduleMap;
        }

        /** 
         * Method returns absences per date 
         * 
         * @param date 
         * @return dictionary linking staff id with their absences ranges 
         */
        private Dictionary<int, List<TimeRange>> getListOfAllAbsencesPerDate(string date) {
            Dictionary<int, List<TimeRange>> absencesPerMember = new Dictionary<int, List<TimeRange>>();

            List<IModel> registeredAbsences = absenceRepo.getAbsencesPerDate(date);
            if (registeredAbsences.Count != 0) {
                foreach (AbsenceModel absence in registeredAbsences) {
                    int staffId = absence.staffId;
                    if (!absencesPerMember.ContainsKey(staffId)) {
                        absencesPerMember.Add(staffId, new List<TimeRange>());
                    }
                    absencesPerMember[staffId].Add(new TimeRange(absence.startTime, absence.endTime));
                }
            }
            return absencesPerMember;
        }

        /** 
         * Method returns bookings per staff member per date 
         * 
         * @param date
         * @return dictionary linking bookings with staff members
         */
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

        /** 
         * Method checks if a giveb time exists in any of time ranges 
         * 
         * @param list contains list of time  ranges 
         * @param time 
         * @return evaluation of time being in the timerange
         */
        private bool isInAnyTimeRange(List<TimeRange> list, TimeSpan time) {
            foreach (TimeRange timeRange in list) {
                if (timeRange.isInTimeRange(time)) {
                    return true;
                }
            }
            return false;
        }

        /** 
         * Method is a debugging tool 
         * 
         * @param appointmentList
         */
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
