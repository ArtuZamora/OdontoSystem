using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IOrthodonticPatientRecordRepository
    {

        Task<IEnumerable<OrthodonticPatientRecord>> GetAllAsync();
        Task<OrthodonticPatientRecord> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(OrthodonticPatientRecord orthodonticPatientRecord);
        Task<bool> UpdateAsync(OrthodonticPatientRecord orthodonticPatientRecord);
      
    }
}
