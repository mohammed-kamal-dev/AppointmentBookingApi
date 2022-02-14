using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Dtos.Appointment;
using AppointmentBookingApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentContext _context;
        public AppointmentRepository(AppointmentContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            var result = await _context.Appointments
                .Where(x => x.DeletedOn == null)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Period)
                .ToListAsync();

            return result;
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            var result = await _context.Appointments.AsNoTracking()
                .Where(x => x.DeletedOn == null)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Period)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorAndPeriod(AppointmentQueryDto appointmentQueryDto)
        {
            var query = _context.Appointments
                .Where(x => x.DeletedOn == null)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Period)
                .AsQueryable();

            if (appointmentQueryDto.DoctorId.HasValue)
            { 
                query = query.Where(x => x.DoctorId == appointmentQueryDto.DoctorId);
            }

            if (appointmentQueryDto.PeriodId.HasValue)
            {
                query = query.Where(x => x.PeriodId == appointmentQueryDto.PeriodId);
            }

            var result = await query.ToListAsync();

            return result;


        }

        public Task<List<Appointment>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }


        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            appointment.DeletedOn = DateTime.Now;
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

       
    }
}
