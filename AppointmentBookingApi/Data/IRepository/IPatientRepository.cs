
using AppointmentBookingApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.IRepository
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(Guid id);
        Task<List<Patient>> GetAllAsync();
        Task<List<Patient>> GetPagedReponseAsync(int pageNumber, int pageSize);


        Task<Patient> AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
    }
}
