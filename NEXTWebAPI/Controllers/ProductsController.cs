using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Controllers;


namespace NEXTWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static HttpClient Client = new HttpClient();

        // GET api/products
        [HttpGet]
        public string Get()
        {
            try
            {
                var json = new WebClient().DownloadString("https://demo.stylearcade.com.au/api/demo/client/data");
                if (json == null)
                {
                    var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return notFoundResponse.ToString();
                }
                return json;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError).ToString();

            }
        }
    }
}
