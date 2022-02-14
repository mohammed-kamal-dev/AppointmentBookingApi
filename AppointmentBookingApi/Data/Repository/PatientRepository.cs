using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppointmentContext _context;

        public PatientRepository(AppointmentContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            var result = await _context.Patients.ToListAsync();

            return result;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var result = await _context.Patients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public Task<List<Patient>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }


        public async Task<Patient> AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task DeleteAsync(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
