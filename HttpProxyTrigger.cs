using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Acme.Function
{
    public static class HttpProxyTrigger
    {

        [Function("HttpProxyTrigger")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("HttpProxyTrigger");
            logger.LogInformation("HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteAsJsonAsync(new { message = "this is a reverse proxy server to jsonplaceholder.typecode.com" });

            return response;
        }
    }
}
