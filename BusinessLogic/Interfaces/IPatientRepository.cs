using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPatientRepository
    {

        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Patient patient);
        Task<bool> UpdateAsync(Patient patient);

    }
}
