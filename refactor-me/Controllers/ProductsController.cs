using System;
using System.Web.Http;
using Models;
using Data.ProductData;
using Data.ProductOptionData;
using System.Collections.Generic;
using System.Linq;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private ProductService _productService = new ProductService();
        private ProductOptionService _optionService = new ProductOptionService();

        [Route]
        [HttpGet]
        public List<Product> GetAll()
        {
            return null;
            //return _service.GetProducts();
        }

        [Route]
        [HttpGet]
        public List<Product> SearchByName(string name)
        {
            return null;
            //return _service.GetProductsByName(name);
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            return null;
            /*var product = _service.GetProduct(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;*/
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            //_service.Create(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            //var existingProduct = _service.GetProduct(id);

            //if (existingProduct != null)
            //{
            //    _service.Update(product);
            //}
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            //// Check product exists first
            //var existingProduct = _service.GetProduct(id);

            //if(existingProduct != null)
            //{
            //    _service.Delete(id);
            //}
        }


        // TODO: Move options into ProductOptionController?
        [Route("{productId}/options")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            // Get product options and map to ProductOptionDto
            return _optionService.GetProductOptions(productId);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOptionDto GetOption(Guid productId, Guid id)
        {
            // Original code I believe has a bug - it has both productId and Id but only uses Id.
            // In original ProductOption class it assumes the id is ProductId.
            // Updated to use both, and ensure that both productId and Id are correct.
            return _optionService.GetOptionForProduct(productId, id);
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            _optionService.Create(productId, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid productId, ProductOption option)
        {
            _optionService.Update(productId, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid productId, Guid id)
        {
            _optionService.Delete(productId, id);
        }

       
    }
}
