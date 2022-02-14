using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.Repository
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly AppointmentContext _context;
        public PeriodRepository(AppointmentContext context)
        {
            _context = context;
        }

        public async Task<List<Period>> GetAllAsync()
        {
            var result = await _context.Periods.ToListAsync();

            return result;
        }

        public async Task<Period> GetByIdAsync(Guid id)
        {
            var result = await _context.Periods.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public Task<List<Period>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Period> AddAsync(Period period)
        {
            await _context.Periods.AddAsync(period);
            await _context.SaveChangesAsync();

            return period;
        }

        public async Task DeleteAsync(Period period)
        {
            _context.Periods.Remove(period);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Period period)
        {
            _context.Periods.Update(period);
            await _context.SaveChangesAsync();
        }
    }
}
