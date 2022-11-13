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
    public class ConstraintsRepository : IConstraintsRepository
    {
        protected readonly AppDbContext _context;
        public ConstraintsRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<bool> CreateAsync(Constraints constraints)
        {
            var flag = false;
            try
            {
                await _context.Constraints.AddAsync(constraints);
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
                var entity = await _context.Constraints.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Constraints.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Constraints constraints)
        {

            var flag = false;
            try
            {
                _context.Constraints.Update(constraints);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Constraints> DetailsAsync(long Id)
        {

            var details = await _context.Constraints.FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<Constraints>> GetAllAsync()
        {

            var response = await _context.Constraints.ToListAsync();
            return (IEnumerable<Constraints>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
