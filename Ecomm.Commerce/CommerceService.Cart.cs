using System;
using System.Linq;
using System.Data.Entity;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public partial class CommerceService
    {
        public void CreateShoppingCart(Guid identifier)
        {
            using (var context = contextFunc())
            {
                var shoppingCart = new ShoppingCart {UuId = identifier, DateCreated = DateTime.UtcNow};
                context.ShoppingCarts.Add(shoppingCart);
                context.SaveChanges();
            }
        }

        public void CreateShoppingCart(string ownerIdentifier)
        {
            using (var context = contextFunc())
            {
                var shoppingCart = new ShoppingCart { OwnerIdentifier = ownerIdentifier, UuId = Guid.NewGuid(), DateCreated = DateTime.UtcNow};
                context.ShoppingCarts.Add(shoppingCart);
                context.SaveChanges();
            }
            
        }

        public void MergeShoppingCart(string ownerIdentifier, params Guid[] cartIdentifiers)
        {
            using (var context = contextFunc())
            {
                var ownerCart = context.ShoppingCarts.FirstOrDefault(c => c.OwnerIdentifier == ownerIdentifier);
                if (ownerCart == null)
                {
                    CreateShoppingCart(ownerIdentifier);
                    ownerCart = context.ShoppingCarts.FirstOrDefault(c => c.OwnerIdentifier == ownerIdentifier);
                }

                foreach (var identifier in cartIdentifiers)
                {
                    var anonymousCart = context.ShoppingCarts.FirstOrDefault(c => c.UuId == identifier);
                    if (anonymousCart == null)
                    {
                        continue;
                    }

                    foreach (var cartItem in anonymousCart.Items)
                    {
                        if (ownerCart.Items.Any(i => i.ERPCode == cartItem.ERPCode))
                        {
                            ownerCart.Items.First(i => i.ERPCode == cartItem.ERPCode).Quantity += cartItem.Quantity;
                        }
                        else
                        {
                            cartItem.Cart = ownerCart;
                            ownerCart.Items.Add(cartItem);
                        }
                    }

                    context.ShoppingCarts.Remove(anonymousCart);
                }

                context.SaveChanges();
            }
        }

        public bool AddItemToCart(Guid identifier, ShoppingCartItem item)
        {
            using (var context = contextFunc())
            {
                var cart = context.ShoppingCarts.Include(sc => sc.Items).FirstOrDefault(sc => sc.UuId == identifier);
                if (cart == null)
                {
                    throw new NullReferenceException(string.Format("No cart found with identifier \"{0}\"", identifier));
                }

                return AddItemToCart(item, cart, context);
            }
        }

        public bool AddItemToCart(string ownerIdentifier, ShoppingCartItem item)
        {
            using (var context = contextFunc())
            {
                var cart =
                    context.ShoppingCarts.Include(sc => sc.Items)
                        .FirstOrDefault(sc => sc.OwnerIdentifier == ownerIdentifier);
                if (cart == null)
                {
                    throw new NullReferenceException(string.Format("No cart found for \"{0}\"", ownerIdentifier));
                }

                return AddItemToCart(item, cart, context);
            }
        }

        public bool ChangeCartItemQuantity(int id, int newQuantity)
        {
            using (var context = contextFunc())
            {
                var cartItem = context.ShoppingCartItems.FirstOrDefault(i => i.Id == id);
                if (cartItem == null)
                {
                    throw new NullReferenceException(string.Format("Cart item with id \"{0}\" not found.", id));
                }

                if (newQuantity < 1)
                {
                    context.ShoppingCartItems.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = newQuantity;
                }

                return context.SaveChanges() > 0;
            }
        }


        public ShoppingCart RetrieveCart(Guid identifier)
        {
            using (var context = contextFunc())
            {
                var cart = context.ShoppingCarts.Include(sc => sc.Items).FirstOrDefault(sc => sc.UuId == identifier);
                return cart;
            }
        }

        public ShoppingCart RetrieveCart(string ownerIdentifier)
        {
            using (var context = contextFunc())
            {
                var cart =
                    context.ShoppingCarts.Include(sc => sc.Items)
                        .FirstOrDefault(sc => sc.OwnerIdentifier == ownerIdentifier);
                return cart;
            }
        }

        private static bool AddItemToCart(ShoppingCartItem item, ShoppingCart cart, ICommerceDataContext context)
        {
            if (cart.Items.Any(i => i.ERPCode == item.ERPCode))
            {
                item.DateUpdated = DateTime.UtcNow;
                cart.Items.First(i => i.ERPCode == item.ERPCode).Quantity += item.Quantity;
            }
            else
            {
                item.DateCreated = DateTime.UtcNow;
                cart.Items.Add(item);
                cart.DateUpdated = DateTime.UtcNow;
            }

            return context.SaveChanges() > 0;
        }
    }
}