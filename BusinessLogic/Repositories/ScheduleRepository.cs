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
    public class ScheduleRepository : IScheduleRepository
    {
        protected readonly AppDbContext _context;
        public ScheduleRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<bool> CreateAsync(Schedule schedule)
        {
            var flag = false;
            try
            {
                await _context.Schedule.AddAsync(schedule);
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
                var entity = await _context.Schedule.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Schedule.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Schedule schedule)
        {

            var flag = false;
            try
            {
                _context.Schedule.Update(schedule);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Schedule> DetailsAsync(long Id)
        {

            var details = await _context.Schedule.FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {

            var response = await _context.Schedule.ToListAsync();
            return (IEnumerable<Schedule>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
