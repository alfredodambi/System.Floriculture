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
    public class ServiceClient : IServiceClient
    {
        private IRepositoryClient _repositoryClient;

        public ServiceClient(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public Task CreateClientAsync(Client client) => _repositoryClient.CreateAsync(client);

        public Task DeleteClientAsync(int Id) => _repositoryClient.DeleteAsync(Id);


        public Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return _repositoryClient.GetAllAsync();
        }

        public Task<Client> GetClientByIdAsync(int Id)
        {
            return _repositoryClient.GetByIdAsync(Id);
        }

        public Task UpdateClientAsync(Client client) => _repositoryClient.UpdateAsync(client);
       
    }
}
