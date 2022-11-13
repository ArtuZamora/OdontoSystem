using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllAsync();
        Task<Schedule> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Schedule shedule);
        Task<bool> UpdateAsync(Schedule schedule);


    }
}
