using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPatientRecordRepository
    {


        Task<IEnumerable<PatientRecord>> GetAllAsync();
        Task<PatientRecord> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(PatientRecord patientRecord);
        Task<bool> UpdateAsync(PatientRecord patientRecord);


    }
}
