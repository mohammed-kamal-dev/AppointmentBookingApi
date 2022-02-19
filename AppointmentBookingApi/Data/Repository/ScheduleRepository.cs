using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Entities;
using AppointmentBookingApi.ResponseWrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppointmentContext _context;

        public ScheduleRepository(AppointmentContext context)
        {
            _context = context;
        }


        public async Task<Response<List<Appointment>>> CreateSchedule(Schedule scheduleData)
        {
            //List of Timeslots
            List<Appointment> Schedules = new List<Appointment>();

            #region Input Parameters

            //Doctor Info
            var getDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == scheduleData.DoctorId);
            var doctorName = getDoctor.FirstName;

            //assigns year, month, day : if day one 
            DateTime initStartDate = scheduleData.StartDate;
            DateTime initEndDate = scheduleData.EndtDate;

            //Appointments info
            var sessionTime = scheduleData.SessionTime;
            var RestTimeBetweenSession = scheduleData.RestTimeBetweenSession;

            var totalSessionTime = sessionTime + RestTimeBetweenSession;

            var restBetweenPeriod = scheduleData.RestTimeBetweenPeriod;

            //Period info
            var initMorningPeriodStart = scheduleData.MorningPeriodStartTime;
            var initMorningPeriodEnd = scheduleData.MorningPeriodEndTime;

            var initNightPeriodStart = scheduleData.NightPeriodStartTime;
            var initNightPeriodEnd = scheduleData.NightPeriodEndTime;
            #endregion

            /**************************************************/

            
            #region Operation Values
            //Numbers of Doctor Days
            var numbersOfDays = (initEndDate.Date - initStartDate.Date).Days + 1;

            //Numbers of Morning Session Minutes in one day
            var MorningSessionMinutesiInOneDay = initMorningPeriodEnd.Subtract(initMorningPeriodStart).TotalMinutes;

            //Numbers of Night Session Minutes in one day
            var NightSessionMinutesiInOneDay = initNightPeriodEnd.Subtract(initNightPeriodStart).TotalMinutes;

            //Number of morningPeriod sessions in one day
            var numberOfMorningPeriodSessionsInOneDay = MorningSessionMinutesiInOneDay / totalSessionTime;

            //Number of nightPeriod sessions in one day
            var numberOfNightPeriodSessionsInOneDay = NightSessionMinutesiInOneDay / totalSessionTime;

            //Total of sessions of the day
            var totalOfSessionsOfTheDay = numberOfMorningPeriodSessionsInOneDay + numberOfNightPeriodSessionsInOneDay;

            //Total of all day session
            var totalOfAlldaysSessions = totalOfSessionsOfTheDay * numbersOfDays;

            //Changeable parameters

            // assigns year, month, day: if day one
            DateTime VStartDate = initStartDate;

            //DateTime VEndDate = new DateTime(2022, 1, 15);


            //Period info
            var VMorningPeriodStart = new TimeSpan();
            var VMorningPeriodEnd = VMorningPeriodStart.Add(TimeSpan.FromMinutes(20));

            var VNightPeriodStart = new TimeSpan(15, 00, 0);
            var VNightPeriodEnd = new TimeSpan(24, 00, 0);
            #endregion


            #region Create Time Slots to Schedules list
            for (var i = 0; i < totalOfAlldaysSessions; i++)
            {
                
                #region Mornig period per day
                for (int m = 1; m < numberOfMorningPeriodSessionsInOneDay; m++)
                {
                    if (m == 1)
                    {
                        var s = new Appointment()
                        {
                            DoctorId = getDoctor.Id,
                            DoctorName = doctorName,
                            StartTime = initMorningPeriodStart,
                            EndTime = initMorningPeriodStart.Add(TimeSpan.FromMinutes(20)),
                            Period = "Morning",
                            Day = VStartDate
                        };

                        if (s.StartTime.Days >= new TimeSpan(1, 0, 0, 0).Days || s.EndTime.Days >= new TimeSpan(1, 0, 0, 0).Days)
                        {
                            s.StartTime = new TimeSpan(0, 0, 0);
                            s.EndTime = new TimeSpan(0, 0, 0);
                        }

                        Schedules.Add(s);

                        VMorningPeriodStart = s.EndTime;

                        i++;

                    }

                    var s2 = new Appointment()
                    {
                        DoctorId = getDoctor.Id,
                        DoctorName = doctorName,
                        StartTime = VMorningPeriodStart,
                        EndTime = VMorningPeriodStart.Add(TimeSpan.FromMinutes(20)),
                        Period = "Morning",
                        Day = VStartDate
                    };

                    if (s2.StartTime.Days >= new TimeSpan(1, 0, 0, 0).Days || s2.EndTime.Days >= new TimeSpan(1, 0, 0, 0).Days)
                    {
                        s2.StartTime = new TimeSpan(0, 0, 0);
                        s2.EndTime = new TimeSpan(0, 0, 0);
                    }
                    Schedules.Add(s2);

                    VMorningPeriodStart = s2.EndTime;

                    i++;
                }

                #endregion

                #region Night period per day
                for (int n = 1; n < numberOfNightPeriodSessionsInOneDay; n++)
                {
                    if (n == 1)
                    {
                        var s = new Appointment()
                        {
                            DoctorId = getDoctor.Id,
                            DoctorName = doctorName,
                            StartTime = initNightPeriodStart,
                            EndTime = initNightPeriodStart.Add(TimeSpan.FromMinutes(20)),
                            Period = "Night",
                            Day = VStartDate
                        };

                        if (s.StartTime.Days >= new TimeSpan(1, 0, 0, 0).Days || s.EndTime.Days >= new TimeSpan(1, 0, 0, 0).Days)
                        {
                            s.StartTime = new TimeSpan(0, 0, 0);
                            s.EndTime = new TimeSpan(0, 0, 0);
                        }

                        Schedules.Add(s);

                        VNightPeriodStart = s.EndTime;

                        i++;

                    }

                    var s2 = new Appointment()
                    {
                        DoctorId = getDoctor.Id,
                        DoctorName = doctorName,
                        StartTime = VNightPeriodStart,
                        EndTime = VNightPeriodStart.Add(TimeSpan.FromMinutes(20)),
                        Period = "Night",
                        Day = VStartDate
                    };

                    if (s2.StartTime.Days >= new TimeSpan(1, 0, 0, 0).Days || s2.EndTime.Days >= new TimeSpan(1, 0, 0, 0).Days)
                    {
                        s2.StartTime = new TimeSpan(0, 0, 0);
                        s2.EndTime = new TimeSpan(0, 0, 0);
                    }
                    Schedules.Add(s2);

                    VNightPeriodStart = s2.EndTime;

                    //Increase Days
                    if (n == (numberOfNightPeriodSessionsInOneDay - 1)) VStartDate = s2.Day.AddDays(1);

                    i++;
                }


                #endregion

            }

            #endregion

            try
            {
                if(scheduleData.NightPeriodEndTime.Days >= 1)
                {
                    scheduleData.NightPeriodEndTime = new TimeSpan(0, 0, 0);
                }

                await _context.Schedules.AddAsync(scheduleData);
                await _context.Appointments.AddRangeAsync(Schedules);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }

            return new Response<List<Appointment>>() { Count = Schedules.Count, Data = Schedules};

        }

    }
}
