using Models;
using System;
using System.Linq;

namespace Data.ProductOptionData
{
    public class ProductOptionService
    {
        private IProductOptionRepository _repo;

        public ProductOptionService(IProductOptionRepository repo)
        {
            _repo = repo;
        }
       
        // Returns a product option with this id
        public ProductOptionDto GetOptionForProduct(Guid productOption, Guid optionId)
        {
            return MapProductOptionToDto(_repo.GetItemForProduct(productOption, optionId));
        }

        // Returns a number of product options for a particular productId
        public ProductOptionsDto GetProductOptions(Guid productId)
        {
            return new ProductOptionsDto()
                {
                    Items = _repo.GetAllItemsForProduct(productId)
                        .Select((option) => MapProductOptionToDto(option))
                        .ToList()
                };
        }
                
        // Create a product option
        public bool Create(Guid productId, ProductOption productOption)
        {
            // Check if item exists already
            if (_repo.GetItemForProduct(productId, new Guid(productOption.Id)) != null)
            {
                return false;
            }
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
            if (productOption == null)
                return null;

            return new ProductOptionDto()
            {
                Id = new Guid(productOption.Id),
                Name = productOption.Name,
                Description = productOption.Description
            };
        }
    }
}
