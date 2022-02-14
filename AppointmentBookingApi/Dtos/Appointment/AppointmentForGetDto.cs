using AppointmentBookingApi.Dtos.Doctor;
using AppointmentBookingApi.Dtos.Patient;
using AppointmentBookingApi.Dtos.Period;
using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class AppointmentForGetDto
    {
        public Guid Id { get; set; }

        public DateTime Day { get; set; }

        public double SessionTime { get; set; }


        public Guid PatientId { get; set; }
        public PatientForGetDto Patient { get; set; }

        public Guid DoctorId { get; set; }
        public SimpleDoctorInfo Doctor { get; set; }

        public Guid PeriodId { get; set; }
        public PeriodForGetDto Period { get; set; }
    }
}
