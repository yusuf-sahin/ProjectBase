using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Provera.Pamera.Model.Concrete;

namespace Provera.Pamera.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int productId);
        Task<Product> GetByIdAsync(int productId);

    }
}
