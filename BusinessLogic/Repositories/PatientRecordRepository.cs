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
    public class PatientRecordRepository : IPatientRecordRepository
    {
        protected readonly AppDbContext _context;
        public PatientRecordRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<bool> CreateAsync(PatientRecord patientRecord)
        {
            var flag = false;
            try
            {
                await _context.PatientRecord.AddAsync(patientRecord);
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
                var entity = await _context.PatientRecord.FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.PatientRecord.Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(PatientRecord patientRecord)
        {

            var flag = false;
            try
            {
                _context.PatientRecord.Update(patientRecord);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<PatientRecord> DetailsAsync(long Id)
        {

            var details = await _context.PatientRecord.FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<PatientRecord>> GetAllAsync()
        {

            var response = await _context.PatientRecord.ToListAsync();
            return (IEnumerable<PatientRecord>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
