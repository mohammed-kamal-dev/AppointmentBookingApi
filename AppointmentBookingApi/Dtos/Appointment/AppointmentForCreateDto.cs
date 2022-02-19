using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class AppointmentForCreateDto
    {

        public Guid DoctorId { get; set; }

        public string DoctorName { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Period { get; set; }

        public DateTime Day { get; set; }
    }
}
