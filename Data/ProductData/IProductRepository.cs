using Models;
using System;
using System.Collections.Generic;

namespace Data
{
    public interface IProductRepository
    {
        bool Save(Product entity);
        bool Update(Product entity);
        bool Delete(Guid id);
        Product GetProduct(Guid id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByName(string name);
    }

}
