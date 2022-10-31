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
    public class OrthodonticPatientRecordRepository : IOrthodonticPatientRecordRepository
    {
        protected readonly AppDbContext _context;
        public OrthodonticPatientRecordRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<bool> CreateAsync(OrthodonticPatientRecord orthodonticPatientRecord)
        {
            var flag = false;
            try
            {
                await _context.Set<OrthodonticPatientRecord>().AddAsync(orthodonticPatientRecord);
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
                var entity = await _context.Set<OrthodonticPatientRecord>().FindAsync(Id);

                if (entity == null)
                    throw new Exception("Entity is null");

                _context.Set<OrthodonticPatientRecord>().Remove(entity);
                await _context.SaveChangesAsync();

                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public async Task<bool> UpdateAsync(OrthodonticPatientRecord orthodonticPatientRecord)
        {

            var flag = false;
            try
            {
                _context.Set<OrthodonticPatientRecord>().Update(orthodonticPatientRecord);
                await _context.SaveChangesAsync();
                flag = true;
            }

            catch (Exception)
            {

                throw;
            }
            return flag;

        }

        public async Task<OrthodonticPatientRecord> DetailsAsync(long Id)
        {

            var details = await _context.Set<OrthodonticPatientRecord>().FindAsync(Id);
            return details;

        }

        public async Task<IEnumerable<OrthodonticPatientRecord>> GetAllAsync()
        {

            var response = await _context.Set<OrthodonticPatientRecord>().ToListAsync();
            return (IEnumerable<OrthodonticPatientRecord>)response;


            // List<Patient> listaPatient = await _context.Set<Patient>().ToListAsync; return listaPatient;
        }
    }
}
