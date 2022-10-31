using BusinessLogic.Context;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        protected readonly AppDbContext _context;
        public InventoryRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<bool> CreateAsync(Inventory inventory)
        {
            var flag = false;
            try
            {
                await _context.Set<Inventory>().AddAsync(inventory);
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
                var entity = await _context.Set<Inventory>().FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Set<Inventory>().Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Inventory inventory)
        {

            var flag = false;
            try
            {
                _context.Set<Inventory>().Update(inventory);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Inventory> DetailsAsync(long Id)
        {

            var details = await _context.Set<Inventory>().FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {

            var response = await _context.Set<Inventory>().ToListAsync();
            return (IEnumerable<Inventory>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
