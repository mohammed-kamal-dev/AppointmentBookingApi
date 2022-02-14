using AppointmentBookingApi.Dtos.Appointment;
using AppointmentBookingApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.IRepository
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(Guid id);
        Task<List<Appointment>> GetAllAsync();

        Task<List<Appointment>> GetAppointmentsByDoctorAndPeriod(AppointmentQueryDto appointmentQueryDto);
        Task<List<Appointment>> GetPagedReponseAsync(int pageNumber, int pageSize);


        Task<Appointment> AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);
    }
}
