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
                await _context.Database.ExecuteSqlRawAsync("INSERT INTO Agenda(Date, Hour, State, TreatmentId, PatientId, DoctorId) VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                        agenda.Date,
                        agenda.Hour,
                        agenda.State,
                        agenda.Treatment == null ? null : agenda.Treatment.Id,
                        agenda.Patient.Id,
                        agenda.DoctorId);
                flag = true;
            }

            catch (Exception e)
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
                await _context.Database.ExecuteSqlRawAsync("UPDATE Agenda SET Date = {1}, Hour = {2}, State = {3}, TreatmentId = {4}, PatientId = {5} WHERE Id = {0}",
                        agenda.Id,
                        agenda.Date,
                        agenda.Hour,
                        agenda.State,
                        agenda.Treatment == null ? null : agenda.Treatment.Id,
                        agenda.Patient.Id);
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
