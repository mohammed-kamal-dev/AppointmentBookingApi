using System;

namespace AppointmentBookingApi.Entities
{
    public class Appointment : AuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime Day { get; set; }

        public  double SessionTime { get; set; }


        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Guid PeriodId { get; set; }
        public Period Period { get; set; }

    }
}
