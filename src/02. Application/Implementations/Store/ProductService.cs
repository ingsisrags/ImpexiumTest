using Common.Interfaces.Repository;
using Interfaces.Store;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Implementations.Store
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryAsync<Product> _productRepository;

        public ProductService(IRepositoryAsync<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.ListAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddNewProduct(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);

            if (productToUpdate == null)
            {
                return;
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Quantity = product.Quantity;
            
            await _productRepository.UpdateAsync(productToUpdate);
        }
        
        public async Task DeleteProductAsync(int productId)
        {
            var basket = await _productRepository.GetByIdAsync(productId);
            await _productRepository.DeleteAsync(basket);
        }
    }
}