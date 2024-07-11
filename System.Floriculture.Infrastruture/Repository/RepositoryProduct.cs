using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Floriculture.Domain.Interface;
using System.Floriculture.Domain.Models;
using System.Floriculture.Infrastruture.Context;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Infrastruture.Repository
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly string _connectionString;

        public RepositoryProduct(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateAsync(Product entity)
        {
            var _myContext = new MyContext(_connectionString);
            _myContext.products.Add(entity);
            await _myContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var _myContext = new MyContext(_connectionString);
            Product product = _myContext.products.Find(Id);
            _myContext.products.Remove(product);
            await _myContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var _myContext = new MyContext(_connectionString);
            return await _myContext.products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var _myContext = new MyContext(_connectionString);
            return await _myContext.products.FindAsync(id);
        }

        public async Task UpdateAsync(Product entity)
        {
            var _myContext = new MyContext(_connectionString);
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
        }
    }
}
