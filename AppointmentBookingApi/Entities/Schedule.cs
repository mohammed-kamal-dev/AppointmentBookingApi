using System;

namespace AppointmentBookingApi.Entities
{
    public class Schedule : AuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public double SessionTime { get; set; }

        public double RestTimeBetweenSession { get; set; }

        public double RestTimeBetweenPeriod { get; set; }

        public TimeSpan MorningPeriodStartTime { get; set; }
        public TimeSpan MorningPeriodEndTime { get; set; }

        public TimeSpan NightPeriodStartTime { get; set; }
        public TimeSpan NightPeriodEndTime { get; set; }


        public Guid? PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
