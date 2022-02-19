using System;

namespace AppointmentBookingApi.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string DoctorName { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Period { get; set; }

        public DateTime Day { get; set; } 
    }
}
