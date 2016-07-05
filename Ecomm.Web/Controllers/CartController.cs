using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecomm.Catalog;
using Ecomm.Commerce;
using Ecomm.Commerce.Data;

namespace Ecomm.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICommerceService commerceService;
        private readonly ICatalogService catalogService;

        public CartController(ICommerceService commerceService, ICatalogService catalogService)
        {
            this.commerceService = commerceService;
            this.catalogService = catalogService;
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult CartContents()
        {
            return PartialView(GetCart());
        }

        public ActionResult CartSummary()
        {
            return PartialView(GetCart());
        }

        public ActionResult AddToCart(string erpCode, int quantity)
        {
            var cart = GetCart();
            if (cart == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    commerceService.CreateShoppingCart(User.Identity.Name);
                }
                else
                {
                    commerceService.CreateShoppingCart(GetCartIdentifier());
                }
            }

            var product = catalogService.RetrieveProduct(erpCode);
            var cartItem = new ShoppingCartItem
            {
                ERPCode = product.ERPCode,
                Quantity = quantity,
                Name = product.Name,
                TaxRatio = product.TaxRatio,
                UnitPrice = product.UnitPrice,
            };

            var cartOperationSuccessFul = false;
            if (User.Identity.IsAuthenticated)
            {
                cartOperationSuccessFul = commerceService.AddItemToCart(User.Identity.Name, cartItem);
            }
            else
            {
                cartOperationSuccessFul = commerceService.AddItemToCart(GetCartIdentifier(), cartItem);
            }

            if (cartOperationSuccessFul)
            {
                return Json(new { Message = "Product added to cart!" }, JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int) HttpStatusCode.Conflict;
            return Json(new {Message = "Unable to add item to cart!"}, JsonRequestBehavior.AllowGet);
        }

        private ShoppingCart GetCart()
        {
            var cart = User.Identity.IsAuthenticated
                ? commerceService.RetrieveCart(User.Identity.Name)
                : commerceService.RetrieveCart(GetCartIdentifier());
            return cart;
        }

        public ActionResult UpdateCartQuantity(int id, int newQuantity)
        {
            var cart = GetCart();
            if (cart == null)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(new {Message = "No cart found!"}, JsonRequestBehavior.AllowGet);
            }

            if (cart.Items.All(i => i.Id != id))
            {
                Response.StatusCode = (int) HttpStatusCode.Forbidden;
                return Json(new {Message = "No cart item found with given id!"}, JsonRequestBehavior.AllowGet);
            }

            if (commerceService.ChangeCartItemQuantity(id, newQuantity))
            {
                return Json(new { Message = "Cart item modified" }, JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int) HttpStatusCode.Conflict;
            return Json(new {Message = "Unable to modify cart item!"}, JsonRequestBehavior.AllowGet);
        }

        private Guid GetCartIdentifier()
        {
            if (Session == null)
            {
                return Guid.Empty;
            }

            if (Session["CartIdentifier"] != null)
            {
                return (Guid) Session["CartIdentifier"];
            }

            Session["CartIdentifier"] = Guid.NewGuid();
            return (Guid) Session["CartIdentifier"];
        }
    }
}