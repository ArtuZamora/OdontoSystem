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
    public class TreatmentRepository : ITreatmentRepository
    {
        protected readonly AppDbContext _context;
        public TreatmentRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<bool> CreateAsync(Treatment treatment)
        {
            var flag = false;
            try
            {
                await _context.Treatment.AddAsync(treatment);
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
                var entity = await _context.Treatment.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Treatment.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Treatment treatment)
        {

            var flag = false;
            try
            {
                _context.Treatment.Update(treatment);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Treatment> DetailsAsync(long Id)
        {

            var details = await _context.Treatment.FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<Treatment>> GetAllAsync()
        {

            var response = await _context.Treatment.ToListAsync();
            return (IEnumerable<Treatment>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }

    }
}
