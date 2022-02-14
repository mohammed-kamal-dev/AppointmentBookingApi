using AppointmentBookingApi.Dtos.Appointment;
using AppointmentBookingApi.Dtos.Doctor;
using AppointmentBookingApi.Dtos.Patient;
using AppointmentBookingApi.Dtos.Period;
using AppointmentBookingApi.Entities;
using AppointmentBookingApi.Enums;
using AutoMapper;
using System;

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

            //Appointment
            CreateMap<AppointmentForCreateDto, Appointment>();
            CreateMap<AppointmentForUpdateDto, Appointment>();
            CreateMap<Appointment,AppointmentForGetDto>();

        }
    }
}
