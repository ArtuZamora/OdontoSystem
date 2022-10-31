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
    public class AgendaRepository : IAgendaRepository
    {
        protected readonly AppDbContext _context;
        public AgendaRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<bool> CreateAsync(Agenda agenda)
        {
            var flag = false;
            try
            {
                await _context.Set<Agenda>().AddAsync(agenda);
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
                var entity = await _context.Agenda.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Agenda.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Agenda agenda)
        {

            var flag = false;
            try
            {
                _context.Agenda.Update(agenda);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Agenda> DetailsAsync(long Id)
        {

            var details = await _context.Agenda.FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<Agenda>> GetAllAsync()
        {

            var response = await _context.Agenda.ToListAsync();
            return response;
        }
    }
}
