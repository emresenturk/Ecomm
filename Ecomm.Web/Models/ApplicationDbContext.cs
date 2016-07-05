using System.Data.Entity;
using Ecomm.Commerce.Data;
using Ecomm.Shipment.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ecomm.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, ICommerceDataContext, IShipmentServiceDataContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
    }
}