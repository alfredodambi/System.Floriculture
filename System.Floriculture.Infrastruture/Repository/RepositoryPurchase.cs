using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Floriculture.Domain.Interface;
using System.Floriculture.Domain.Models;
using System.Floriculture.Infrastruture.Context;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Infrastruture.Repository
{
    public class RepositoryPurchase : IRepositoryPurchase
    {

        private readonly string _connectionString;

        public RepositoryPurchase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateAsync(Purchase entity)
        {
            var _myContext = new MyContext(_connectionString);
            _myContext.purchases.Add(entity);
            await _myContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var _myContext = new MyContext(_connectionString);
            Purchase purchase = _myContext.purchases.Find(Id);
            _myContext.purchases.Remove(purchase);
            await _myContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            var _myContext = new MyContext(_connectionString);
            return await _myContext.purchases.Include("Client").ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            var _myContext = new MyContext(_connectionString);
            return await _myContext.purchases.FindAsync(id);
        }

        public async Task UpdateAsync(Purchase entity)
        {
            var _myContext = new MyContext(_connectionString);
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
        }
    }
}
