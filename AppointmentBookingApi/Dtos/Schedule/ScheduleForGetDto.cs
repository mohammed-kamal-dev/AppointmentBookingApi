using AppointmentBookingApi.Dtos.Doctor;
using AppointmentBookingApi.Dtos.Patient;
using AppointmentBookingApi.Dtos.Period;
using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class ScheduleForGetDto
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public double SessionTime { get; set; }

        public double RestTimeBetweenSession { get; set; }

        public double RestTimeBetweenPeriod { get; set; }

        public string MorningPeriodStartTime { get; set; }
        public string MorningPeriodEndTime { get; set; }

        public string NightPeriodStartTime { get; set; }
        public string NightPeriodEndTime { get; set; }

        public Guid PatientId { get; set; }
        public PatientForGetDto Patient { get; set; }

        public Guid DoctorId { get; set; }
        public SimpleDoctorInfo Doctor { get; set; }

        public Guid PeriodId { get; set; }
        public PeriodForGetDto Period { get; set; }
    }
}
