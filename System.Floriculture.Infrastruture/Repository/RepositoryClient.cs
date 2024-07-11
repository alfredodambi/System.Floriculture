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
    public class RepositoryClient : IRepositoryClient
    {
        private readonly string _connectionString;

        public RepositoryClient(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateAsync(Client entity)
        {
            var _myContext = new MyContext(_connectionString);
            _myContext.clients.Add(entity);
            await _myContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var _myContext = new MyContext(_connectionString);
            Client client = _myContext.clients.Find(Id);
            _myContext.clients.Remove(client);
            await _myContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var _myContext = new MyContext(_connectionString);
            return await _myContext.clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            var _myContext = new MyContext(_connectionString);
            return await _myContext.clients.FindAsync(id);
        }

        public async Task UpdateAsync(Client entity)
        {
            var _myContext = new MyContext(_connectionString);
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
        }
    }
}
