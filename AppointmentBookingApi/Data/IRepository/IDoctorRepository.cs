using AppointmentBookingApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.IRepository
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetByIdAsync(Guid id);
        Task<List<Doctor>> GetAllAsync();
        Task<List<Doctor>> GetPagedReponseAsync(int pageNumber, int pageSize);


        Task<Doctor> AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
    }
}
