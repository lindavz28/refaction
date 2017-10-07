using System;
using System.Web.Http;
using Models;
using Data.ProductOptionData;
using Data.Exceptions;
using System.Net.Http;
using System.Net;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductOptionsController : ApiController
    {
        private ProductOptionService _optionService = new ProductOptionService();
        
        [Route("{productId}/options")]
        [HttpGet]
        public HttpResponseMessage GetOptions(Guid productId)
        {
            try
            {
                // Get product options and map to ProductOptionDto
                var options = _optionService.GetProductOptions(productId);

                if (options == null)
                    return Request.NotFound();

                return Request.CreateResponse(HttpStatusCode.OK, options);
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public HttpResponseMessage GetOption(Guid productId, Guid id)
        {
            try
            {
                // Original code I believe has a bug - it has both productId and Id but only uses Id.
                // In original ProductOption class it assumes the id is ProductId.
                // Updated to use both, and ensure that both productId and Id are correct.
                var productOption = _optionService.GetOptionForProduct(productId, id);
               
                if (productOption == null)
                    return Request.NotFound(id);

                return Request.CreateResponse(HttpStatusCode.OK, productOption);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(e.Message);
            }

        }

        [Route("{productId}/options")]
        [HttpPost]
        public HttpResponseMessage CreateOption(Guid productId, ProductOption option)
        {
            try
            {
                _optionService.Create(productId, option);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateOption(Guid productId, ProductOption option)
        {
            try
            {
                var updated = _optionService.Update(productId, option);
                if (updated)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }

                // Nothing changed
                return Request.NotFound(new Guid(option.Id));
            }
            catch (Exception e)
            {
                return Request.Error(e.Message);
            }

        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteOption(Guid productId, Guid id)
        {
            try
            {
                var updated = _optionService.Delete(productId, id);
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
