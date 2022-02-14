using System;

namespace AppointmentBookingApi.Service
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
