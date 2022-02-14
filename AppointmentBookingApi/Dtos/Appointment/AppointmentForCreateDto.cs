using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class AppointmentForCreateDto
    {

        public DateTime Day { get; set; }

        public double SessionTime { get; set; }

        public Guid PatientId { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PeriodId { get; set; }
    }
}
