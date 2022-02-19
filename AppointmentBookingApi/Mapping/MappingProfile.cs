using AppointmentBookingApi.Dtos.Appointment;
using AppointmentBookingApi.Dtos.Doctor;
using AppointmentBookingApi.Dtos.Patient;
using AppointmentBookingApi.Dtos.Period;
using AppointmentBookingApi.Entities;
using AppointmentBookingApi.Enums;
using AutoMapper;
using System;
using System.Globalization;

namespace AppointmentBookingApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Period
            CreateMap<PeriodForCreateDto, Period>();
            CreateMap<PeriodForUpdateDto , Period>();
            CreateMap<Period, PeriodForGetDto>();


            //Patient
            CreateMap<PatientForCreateDto, Patient>();
            CreateMap<PatientForUpdateDto, Patient>();
            CreateMap<Patient,PatientForGetDto>();

            //Doctor
            CreateMap<DoctorForCreateDto, Doctor>();
            CreateMap<DoctorForUpdateDto, Doctor>();
            CreateMap<Doctor,DoctorForGetDto>();
            CreateMap<Doctor, SimpleDoctorInfo>();

            //Schedule
            CreateMap<ScheduleForCreateDto, Schedule>()
                .ForMember(x => x.MorningPeriodStartTime, opt => opt.MapFrom(x => ConvertStringToTimeSpan(x.MorningPeriodStartTime)))
                .ForMember(x => x.MorningPeriodEndTime, opt => opt.MapFrom(x => ConvertStringToTimeSpan(x.MorningPeriodEndTime)))
                .ForMember(x => x.NightPeriodStartTime, opt => opt.MapFrom(x => ConvertStringToTimeSpan(x.NightPeriodStartTime)))
                .ForMember(x => x.NightPeriodEndTime, opt => opt.MapFrom(x => ConvertStringToTimeSpan(x.NightPeriodEndTime)));


            CreateMap<ScheduleForUpdateDto, Schedule>();

            CreateMap<Schedule,ScheduleForGetDto>();

            //Appointment
            CreateMap<AppointmentForCreateDto, Appointment>();
            CreateMap<AppointmentForUpdateDto, Appointment>();

            CreateMap<Appointment, AppointmentForGetDto>()
                .ForMember(x => x.StartTime, opt => opt.MapFrom(x => ConvertTimeSpanToString(x.StartTime)))
                .ForMember(x => x.EndTime, opt => opt.MapFrom(x => ConvertTimeSpanToString(x.EndTime)))
                .ForMember(x => x.Day, opt => opt.MapFrom(x => x.Day.ToShortDateString()));


        }

        //Helpers
        public TimeSpan ConvertStringToTimeSpan(string text)
        {
            

            DateTime dateTime = DateTime.ParseExact(text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None);

            TimeSpan span = dateTime.TimeOfDay;

            if (span.Days >= new TimeSpan(1,0,0,0).Days) 
            {
                span = new TimeSpan(0, 0, 0); 
            }

            if (span == new TimeSpan(0, 0, 0)) span = new TimeSpan(24, 0, 0);

            return span;
        }

        public string ConvertTimeSpanToString(TimeSpan timeSpan)
        {
            TimeSpan span = new TimeSpan();

            span = timeSpan;
            DateTime time = DateTime.Today.Add(span);

            string displayTime = time.ToString("hh:mm tt"); //  example : "03:00 AM"

            return displayTime;
        }
    }
}
