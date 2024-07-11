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
    public class ServiceProduct : IServiceProduct
    {

        private IRepositoryProduct _repositoryProduct;

        public ServiceProduct(IRepositoryProduct _repositortProduct) 
        {
            _repositoryProduct = _repositortProduct;
        }
        public Task CreateProductAsync(Product product) => _repositoryProduct.CreateAsync(product);

        public Task DeleteProductAsync(int Id) => _repositoryProduct.DeleteAsync(Id);

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return _repositoryProduct.GetAllAsync();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
           return _repositoryProduct.GetByIdAsync(id);
        }

        public Task UpdateProductAsync(Product product) => UpdateProductAsync(product);

    }
}
