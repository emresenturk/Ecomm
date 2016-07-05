using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecomm.Commerce;

namespace Ecomm.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICommerceService commerceService;

        public CheckoutController(ICommerceService commerceService)
        {
            this.commerceService = commerceService;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlaceOrder()
        {
            throw new NotImplementedException();
        }

        public ActionResult CheckoutCartSummary()
        {
            throw new NotImplementedException();
        }

        public ActionResult CheckoutCompleted(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}