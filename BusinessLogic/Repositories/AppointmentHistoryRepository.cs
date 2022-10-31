using BusinessLogic.Context;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class AppointmentHistoryRepository : IAppointmentHistoryRepository
    {
        protected readonly AppDbContext _context;
        public AppointmentHistoryRepository(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<bool> CreateAsync(AppointmentHistory appointmentHistory)
        {
            var flag = false;
            try
            {
                await _context.Set<AppointmentHistory>().AddAsync(appointmentHistory);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<bool> DeleteAsync(long Id)
        {
            var flag = false;
            try
            {
                var entity = await _context.Set<AppointmentHistory>().FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Set<AppointmentHistory>().Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(AppointmentHistory appointmentHistory)
        {

            var flag = false;
            try
            {
                _context.Set<AppointmentHistory>().Update(appointmentHistory);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<AppointmentHistory> DetailsAsync(long Id)
        {

            var details = await _context.Set<AppointmentHistory>().FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<AppointmentHistory>> GetAllAsync()
        {

            var response = await _context.Set<AppointmentHistory>().ToListAsync();
            return (IEnumerable<AppointmentHistory>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
