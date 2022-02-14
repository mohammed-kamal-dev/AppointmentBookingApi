using AppointmentBookingApi.Dtos.Period;
using AppointmentBookingApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.IRepository
{
    public interface IPeriodRepository 
    {
        Task<Period> GetByIdAsync(Guid id);
        Task<List<Period>> GetAllAsync();
        Task<List<Period>> GetPagedReponseAsync(int pageNumber, int pageSize);


        Task<Period> AddAsync(Period period);
        Task UpdateAsync(Period period);
        Task  DeleteAsync(Period period);
    }
}
