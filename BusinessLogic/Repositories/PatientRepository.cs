using BusinessLogic.Context;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        protected readonly AppDbContext _context;
        public PatientRepository(AppDbContext context)
        {
            _context = context;

        }



        public async Task<bool> CreateAsync(Patient patient)
        {
            var flag = false;
            try
            {
                await _context.Patient.AddAsync(patient);
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
                var entity = await _context.Patient.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Patient.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
      
            var flag = false;
            try
            {
                _context.Patient.Update(patient);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<Patient> DetailsAsync(long Id)
        {

            var details = await _context.Patient.FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            
            var response = await _context.Patient.ToListAsync(); 
            return (IEnumerable<Patient>)response;


            // List<Patient> listaPatient = await _context.Patient.ToListAsync; return listaPatient;
        }

    }
}
