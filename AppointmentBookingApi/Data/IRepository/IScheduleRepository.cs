using AppointmentBookingApi.Entities;
using AppointmentBookingApi.ResponseWrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.IRepository
{
    public interface IScheduleRepository
    {
        Task<Response<List<Appointment>>> CreateSchedule(Schedule schedule);

    }
}
