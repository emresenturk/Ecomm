using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecomm.Commerce;
using Ecomm.Commerce.Data;
using Ecomm.Shipment;
using Ecomm.Shipment.Data;
using Ecomm.Web.Models;

namespace Ecomm.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICommerceService commerceService;
        private readonly IShipmentService shipmentService;

        public CheckoutController(ICommerceService commerceService, IShipmentService shipmentService)
        {
            this.commerceService = commerceService;
            this.shipmentService = shipmentService;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlaceOrder(OrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", request);
            }

            try
            {
                var order = commerceService.CreateOrder(User.Identity.Name);
                var deliveryAddress = new DeliveryAddress
                {
                    Address = request.Address,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    City = request.City,
                    Email = request.Email,
                    ReferenceCode = order.ReferenceCode,
                    Title = request.Title,
                    ZipCode = request.ZipCode,
                    HouseNumber = request.HouseNumber
                };

                shipmentService.CreateDeliveryAddress(deliveryAddress);

                return RedirectToAction("CheckoutCompleted", new {referenceCode = order.ReferenceCode});
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", "Checkout error.");
                return View("Index", request);

                // log maybe?
            }
        }

        public ActionResult CheckoutCartSummary()
        {
            return PartialView(GetCart());
        }

        public ActionResult CheckoutCompleted(string referenceCode)
        {
            var order = commerceService.RetrieveOrder(referenceCode);
            return View(order);
        }

        private ShoppingCart GetCart()
        {
            var cart = commerceService.RetrieveCart(User.Identity.Name);
            return cart;
        }
    }
}