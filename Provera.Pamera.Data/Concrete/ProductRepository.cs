using Provera.Pamera.Data.Abstract;
using Provera.Pamera.Data.DataAccess.EntityFramework;
using Provera.Pamera.Model.Concrete;

namespace Provera.Pamera.Data.Concrete
{
    public class ProductRepository : EfEntityRepositoryBase<Product, PameraContext>,IProductRepository
    {
       
    }
}
