using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppointmentContext _context;

        public DoctorRepository(AppointmentContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            var result = await _context.Doctors.ToListAsync();

            return result;
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            var result = await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public Task<List<Doctor>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }


        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
