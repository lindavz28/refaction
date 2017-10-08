using System;
using System.Web.Http;
using Models;
using Data.ProductData;
using System.Net;
using Data.Exceptions;
using System.Net.Http;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private ProductService _productService = new ProductService();

        [Route]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var products = _productService.GetAllProducts();

                if (products == null)
                    return Request.NotFound();

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage SearchByName(string name)
        {
            try
            { 
                var products = _productService.GetAllProductsByName(name);

                if (products == null)
                    return Request.NotFound();

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid id)
        {
            try
            {
                var product = _productService.GetProduct(id);

                if (product == null)
                    return Request.NotFound(id);

                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage Create(Product product)
        {
            try
            {
                if(_productService.Create(product) )
                    return Request.CreateResponse(HttpStatusCode.Created);

                return Request.CreateResponse(HttpStatusCode.NoContent, $"Product with Product ID '{product.Id}' already exists");
            }
            catch(Exception e)
            {
                return Request.Error(e.Message);
            }
        }
                
        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Guid id, Product product)
        {
            try
            {
                var updated = _productService.Update(product);
                if (updated)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }

                // Nothing changed
                return Request.NotFound(id);
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                var updated = _productService.Delete(id);
                if (updated)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }

                return Request.NotFound(id);
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }
        }

       
    }
}
