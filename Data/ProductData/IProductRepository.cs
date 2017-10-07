using Models;
using System;
using System.Collections.Generic;

namespace Data
{
    interface IProductRepository
    {
        bool Save(Product entity);
        bool Update(Product entity);
        bool Delete(Guid id);
        Product GetItem(Guid id);
        IEnumerable<Product> GetAllItems();
        IEnumerable<Product> GetItemsByName(string name);
    }

}
