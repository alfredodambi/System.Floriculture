using System;
using System.Collections.Generic;
using System.Floriculture.Application.Interface;
using System.Floriculture.Domain.Interface;
using System.Floriculture.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Application.Services
{
    public class ServicePurchase : IServicePurchase
    {
        private IRepositoryPurchase _repositoryPurchase;

        public ServicePurchase(IRepositoryPurchase repositoryPurchase)
        {
            _repositoryPurchase = repositoryPurchase;
        }

        public Task CreatePurchase(Purchase purchase) => _repositoryPurchase.CreateAsync(purchase);

        public Task DeletePurchase(int Id) => _repositoryPurchase.DeleteAsync(Id);

        public Task<IEnumerable<Purchase>> GetAllPurchase()
        {
            return _repositoryPurchase.GetAllAsync();
        }

        public Task<Purchase> GetPurchaseById(int Id)
        {
            return _repositoryPurchase.GetByIdAsync(Id);
        }

        public Task UpdatePurchase(Purchase purchase) => _repositoryPurchase.UpdateAsync(purchase);
    }
}
