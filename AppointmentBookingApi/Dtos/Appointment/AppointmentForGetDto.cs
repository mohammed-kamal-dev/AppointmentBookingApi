using AppointmentBookingApi.Dtos.Doctor;
using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class AppointmentForGetDto
    {
        public Guid Id { get; set; }

        public Guid DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Period { get; set; }

        public string Day { get; set; }
    }
}
