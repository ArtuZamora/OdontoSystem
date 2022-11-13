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
    public class OdontogramRepository : IOdontogramRepository
    {
        protected readonly AppDbContext _context;
        public OdontogramRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<bool> CreateAsync(Odontogram odontogram)
        {
            var flag = false;
            try
            {
                await _context.Odontogram.AddAsync(odontogram);
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
                var entity = await _context.Odontogram.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Odontogram.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Odontogram odontogram)
        {

            var flag = false;
            try
            {
                _context.Odontogram.Update(odontogram);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Odontogram> DetailsAsync(long Id)
        {

            var details = await _context.Odontogram.FindAsync(Id);
            return details;
            
        }

        public async Task<IEnumerable<Odontogram>> GetAllAsync()
        {

            var response = await _context.Odontogram.ToListAsync();
            return (IEnumerable<Odontogram>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
