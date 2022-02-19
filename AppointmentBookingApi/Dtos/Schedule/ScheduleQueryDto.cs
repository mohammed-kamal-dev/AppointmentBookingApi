using System;

namespace AppointmentBookingApi.Dtos.Appointment
{
    public class ScheduleQueryDto
    {
        public Guid? DoctorId { get; set; }
        public Guid? PeriodId { get; set; }
    }
}
