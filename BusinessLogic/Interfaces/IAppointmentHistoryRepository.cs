using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAppointmentHistoryRepository
    {

        Task<IEnumerable<AppointmentHistory>> GetAllAsync();
        Task<AppointmentHistory> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(AppointmentHistory appointmentHistory);
        Task<bool> UpdateAsync(AppointmentHistory appointmentHistory);



    }
}
