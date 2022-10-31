using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITreatmentRepository
    {

        Task<IEnumerable<Treatment>> GetAllAsync();
        Task<Treatment> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Treatment treatment);
        Task<bool> UpdateAsync(Treatment treatment);
    }
}
