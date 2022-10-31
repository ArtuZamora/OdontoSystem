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
    public class PatientHistoryRepository : IPatientHistoryRepository
    {
        protected readonly AppDbContext _context;
        public PatientHistoryRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<bool> CreateAsync(PatientHistory  patientHistory)
        {
            var flag = false;
            try
            {
                await _context.Set<PatientHistory>().AddAsync(patientHistory);
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
                var entity = await _context.Set<PatientHistory>().FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Set<PatientHistory>().Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(PatientHistory patientHistory)
        {

            var flag = false;
            try
            {
                _context.Set<PatientHistory>().Update(patientHistory);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<PatientHistory> DetailsAsync(long Id)
        {

            var details = await _context.Set<PatientHistory>().FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<PatientHistory>> GetAllAsync()
        {

            var response = await _context.Set<PatientHistory>().ToListAsync();
            return (IEnumerable<PatientHistory>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }

     
    }
}
