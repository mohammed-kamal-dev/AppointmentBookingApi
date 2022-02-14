using System;

namespace AppointmentBookingApi.Dtos.Period
{
    public class PeriodForCreateDto
    {

        public string PeriodType { get; set; }

        public int RestTime { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
