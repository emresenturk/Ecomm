using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Ecomm.Commerce.Data
{
    public interface ICommerceDataContext : IObjectContextAdapter, IDisposable
    {
        DbSet<ShoppingCart> ShoppingCarts { get; set; }

        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderItem> OrderItems { get; set; } 
    }
}