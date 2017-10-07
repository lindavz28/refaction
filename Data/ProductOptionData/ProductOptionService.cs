using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.ProductOptionData
{
    public class ProductOptionService
    {
        // TODO: Needs injection
        private IProductOptionRepository _repo = new ProductOptionRepository();

        // Returns a product option with this id
        public ProductOptionDto GetOptionForProduct(Guid productOption, Guid optionId)
        {
            return MapProductOptionToDto(_repo.GetItemForProduct(productOption, optionId));
        }

        // Returns a number of product options for a particular productId
        public ProductOptions GetProductOptions(Guid productId)
        {
            return new ProductOptions()
                {
                    Items = _repo.GetAllItemsForProduct(productId)
                        .Select((option) => MapProductOptionToDto(option))
                        .ToList()
                };
        }
                
        // Create a product option
        public bool Create(Guid productId, ProductOption productOption)
        {
            return _repo.Save(productId, productOption);
        }

        // Update an existing product option only
        public bool Update(Guid productId, ProductOption productOption)
        {
            return _repo.Update(productId, productOption);
        }

        // Delete a product option by its ID
        public bool Delete(Guid productId, Guid optionId)
        {
            return _repo.Delete(productId, optionId);
        }

        // TODO: Do this with a mapping library
        private ProductOptionDto MapProductOptionToDto(ProductOption productOption)
        {
            return new ProductOptionDto()
            {
                Id = new Guid(productOption.Id),
                Name = productOption.Name,
                Description = productOption.Description
            };
        }
    }
}
