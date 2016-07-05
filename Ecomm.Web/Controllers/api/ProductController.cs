using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecomm.Catalog;
using Ecomm.Catalog.Data;

namespace Ecomm.Web.Controllers.api
{
    public class ProductController : ApiController
    {
        private readonly ICatalogService catalogService;

        public ProductController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        public IEnumerable<Product> Get()
        {
            var request = GetProductRequestParameters();
            int id;
            if (request.ContainsKey("id") && int.TryParse(request["id"], out id))
            {
                return new List<Product> { catalogService.RetrieveProduct(id) };
            }

            if (request.ContainsKey("erpCode") && !string.IsNullOrEmpty(request["erpCode"]))
            {
                return new List<Product> {catalogService.RetrieveProduct(request["erpCode"])};
            }

            return catalogService.ReadProducts();

        }


        private IDictionary<string, string> GetProductRequestParameters()
        {
            var requestDict = Request.GetQueryNameValuePairs().ToDictionary(p => p.Key, p => p.Value);
            return requestDict;
        } 
    }
}
