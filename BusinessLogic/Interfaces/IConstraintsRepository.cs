using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IConstraintsRepository
    {

        Task<IEnumerable<Constraints>> GetAllAsync();
        Task<Constraints> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Constraints constraints);
        Task<bool> UpdateAsync(Constraints constraints);


    }
}
