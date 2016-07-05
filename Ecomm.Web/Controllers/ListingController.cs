using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecomm.Catalog;

namespace Ecomm.Web.Controllers
{
    public class ListingController : Controller
    {
        private readonly ICatalogService catalogService;

        public ListingController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        // GET: Listing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products(int? page)
        {
            var products = catalogService.ListProducts((page.GetValueOrDefault(1) - 1)*10, page.GetValueOrDefault(1)*10,
                null);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", products);
            }

            ViewBag.CurrentPage = page.GetValueOrDefault(1);

            return PartialView(products);
        }

        public ActionResult Product(string erpCode)
        {
            var product = catalogService.RetrieveProduct(erpCode);

            
            return View(product);
        }
    }
}