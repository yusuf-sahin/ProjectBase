using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Provera.Pamera.Business.Abstract;
using Provera.Pamera.Data.Abstract;
using Provera.Pamera.Model.Concrete;

namespace Provera.Pamera.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(new Product { Id = productId });
        }

        public async  Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetListAsync() as List<Product>;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _productRepository.GetAsync(x => x.Id == productId);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }
    }
}
