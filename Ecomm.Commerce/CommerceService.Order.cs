using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public partial class CommerceService
    {
        public bool CreateOrder(Guid cartIdentifier)
        {
            using (var context = contextFunc())
            {
                var cart = context.ShoppingCarts.Include(sc => sc.Items).FirstOrDefault(sc => sc.UuId == cartIdentifier);
                if (cart == null)
                {
                    throw new NullReferenceException(string.Format("No cart found with identifier \"{0}\"", cartIdentifier));
                }

                var order = NewOrderFromCart(cart);
                context.Orders.Add(order);
                if (context.SaveChanges() < 1)
                {
                    return false;
                }

                context.ShoppingCarts.Remove(cart);
                context.SaveChanges();
                return true;
            }
        }
        

        public bool CreateOrder(string ownerIdentifier)
        {
            using (var context = contextFunc())
            {
                var cart =
                    context.ShoppingCarts.Include(sc => sc.Items)
                        .FirstOrDefault(sc => sc.OwnerIdentifier == ownerIdentifier);

                if (cart == null)
                {
                    throw new NullReferenceException(string.Format("No cart found with owner identifier \"{0}\"", ownerIdentifier));
                }

                var order = NewOrderFromCart(cart);
                context.Orders.Add(order);
                if (context.SaveChanges() < 1)
                {
                    return false;
                }

                context.ShoppingCarts.Remove(cart);
                context.SaveChanges();
                return true;
            }
        }

        public Order RetrieveOrder(string referenceCode)
        {
            using (var context = contextFunc())
            {
                var order = context.Orders.Include(o => o.Items).FirstOrDefault(o => o.ReferenceCode == referenceCode);
                return order;
            }
        }

        private static Order NewOrderFromCart(ShoppingCart cart)
        {
            var order = new Order // NWO hahaha
            {
                DateCreated = DateTime.UtcNow,
                DateUpdated = null,
                TotalPrice = cart.TotalPrice,
                TotalTaxAmount = cart.TotalPrice - cart.TotalPriceBeforeTax,
                Items = new List<OrderItem>(),
                ReferenceCode = cart.Id.ToString(),
                OwnerIdentifier = cart.OwnerIdentifier
            };

            foreach (var cartItem in cart.Items)
            {
                order.Items.Add(new OrderItem
                {
                    TotalPrice = cartItem.TotalPrice,
                    ERPCode = cartItem.ERPCode,
                    Name = cartItem.Name,
                    Quantity = cartItem.Quantity,
                    TaxRatio = cartItem.TaxRatio,
                    UnitPrice = cartItem.UnitPrice,
                    DateCreated = DateTime.UtcNow,
                    TaxAmount = cartItem.TaxAmount
                });
            }

            return order;
        }
    }
}