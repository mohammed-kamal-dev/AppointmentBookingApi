using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class AppointmentQueryDto
    {
        public Guid? DoctorId { get; set; }
        public Guid? PeriodId { get; set; }
    }
}
