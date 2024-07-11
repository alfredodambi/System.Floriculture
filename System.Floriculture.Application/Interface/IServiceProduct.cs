using System;
using System.Collections.Generic;
using System.Floriculture.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Application.Interface
{
    public interface IServiceProduct
    {
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int Id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}
