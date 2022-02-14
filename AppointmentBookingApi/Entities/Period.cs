using AppointmentBookingApi.Enums;
using System;

namespace AppointmentBookingApi.Entities
{
    public class Period
    {
        public Guid Id { get; set; }

        public PeriodType PeriodType { get; set; }

        public int RestTime { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
