using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPatientHistoryRepository
    {
        Task<IEnumerable<PatientHistory>> GetAllAsync();
        Task<PatientHistory> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(PatientHistory patientHistory);
        Task<bool> UpdateAsync(PatientHistory patientHistory);


    }
}
