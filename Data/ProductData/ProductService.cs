using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ProductData
{
    public class ProductService
    {
        // Needs injection
        private IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        // Returns a product option with this id
        public ProductDto GetProduct(Guid id)
        {
            return MapProductToDto(_repo.GetProduct(id));
        }

        // Returns all Products
        public ProductsDto GetAllProducts()
        {
            return new ProductsDto()
            {
                Items = _repo.GetAllProducts()
                        .Select((product) => MapProductToDto(product))
                        .ToList()
            };
        }

        // Returns all Products
        public ProductsDto GetAllProductsByName(string name)
        {
            return new ProductsDto()
            {
                Items = _repo.GetProductsByName(name)
                        .Select((product) => MapProductToDto(product))
                        .ToList()
            };
        }

        // Create a product
        public bool Create(Product product)
        {
            // Check if item exists already
            if (_repo.GetProduct(new Guid(product.Id)) != null)
            {
                return false;
            }
            return _repo.Save(product);
        }

        // Update an existing product option only
        public bool Update(Product product)
        {
            return _repo.Update(product);
        }

        // Delete a product option by its ID
        public bool Delete(Guid id)
        {
            return _repo.Delete(id);
        }

        // TODO: Do this with a mapping library
        private ProductDto MapProductToDto(Product product)
        {
            if (product == null)
                return null;

            return new ProductDto()
            {
                Id = new Guid(product.Id),
                Name = product.Name,
                Description = product.Description,
                DeliveryPrice = product.DeliveryPrice,
                Price = product.Price

            };
        }
    }
}
