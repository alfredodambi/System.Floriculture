using System;
using System.Collections.Generic;
using System.Floriculture.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Application.Interface
{
    public interface IServicePurchase
    {
        Task CreatePurchase(Purchase purchase);
        Task UpdatePurchase(Purchase purchase);
        Task DeletePurchase(int Id);
        Task<IEnumerable<Purchase>> GetAllPurchase();
        Task<Purchase> GetPurchaseById(int Id);
        
    }
}
