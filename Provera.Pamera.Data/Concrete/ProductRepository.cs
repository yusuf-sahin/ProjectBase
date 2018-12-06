using Provera.Pamera.Data.Abstract;
using Provera.Pamera.Data.DataAccess.EntityFramework;
using Provera.Pamera.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provera.Pamera.Data.Concrete
{
    public class ProductRepository : EfEntityRepositoryBase<Product, PameraContext>,IProductRepository
    {
    }
}
