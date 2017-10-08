using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace refactor_me
{
    public static class HttpUtils
    {

        // Quick extension method to contain formatting client error responses
        public static HttpResponseMessage Error(this HttpRequestMessage request, string message)
        {
            return request.CreateResponse(HttpStatusCode.InternalServerError, message);
        }

        public static HttpResponseMessage NotFound(this HttpRequestMessage request, Guid id)
        {
            return request.CreateResponse(HttpStatusCode.NotFound, $"Product or Option with ID '{id}' not found");
        }

        public static HttpResponseMessage NotFound(this HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.NotFound, $"No items were found");

        }
    }
}