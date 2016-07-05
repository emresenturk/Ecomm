using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Ecomm.Shipment.Data
{
    public interface IShipmentServiceDataContext : IObjectContextAdapter, IDisposable
    {
        DbSet<DeliveryAddress> DeliveryAddresses { get; set; } 

        int SaveChanges();
    }
}