using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IAgendaRepository
    {

        Task<IEnumerable<Agenda>> GetAllAsync();
        Task<Agenda> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Agenda agenda);
        Task<bool> UpdateAsync(Agenda agenda);



    }
}
