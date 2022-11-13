using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Interfaces
{
    public interface IInventoryRepository
    {


        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> DetailsAsync(long Id);
        Task<bool> DeleteAsync(long Id);
        Task<bool> CreateAsync(Inventory inventory);
        Task<bool> UpdateAsync(Inventory inventory);


    }
}
