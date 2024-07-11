using System;
using System.Collections.Generic;
using System.Floriculture.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Application.Interface
{
    public interface IServiceClient
    {
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int Id);
        Task<Client> GetClientByIdAsync(int Id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
    }
}
