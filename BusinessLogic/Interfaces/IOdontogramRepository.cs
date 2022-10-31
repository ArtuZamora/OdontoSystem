using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IOdontogramRepository
    {

        Task<IEnumerable<Odontogram>> GetAllAsync();
        Task<Odontogram> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Odontogram odontogram);
        Task<bool> UpdateAsync(Odontogram odontogram);


    }
}
