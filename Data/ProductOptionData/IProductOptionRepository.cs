using Models;
using System;
using System.Collections.Generic;

namespace Data
{
    public interface IProductOptionRepository
    {
        bool Save(Guid productId, ProductOption entity);
        bool Update(Guid productId, ProductOption entity);
        bool Delete(Guid productId, Guid id);
        IEnumerable<ProductOption> GetAllItemsForProduct(Guid productId);
        ProductOption GetItemForProduct(Guid productId, Guid optionId);
    }
}
