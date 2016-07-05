using System;
using Ecomm.Shipment.Data;

namespace Ecomm.Shipment
{
    public class ShipmentService : IShipmentService
    {
        private readonly Func<IShipmentServiceDataContext> contextFunc;

        public ShipmentService(Func<IShipmentServiceDataContext> contextFunc)
        {
            this.contextFunc = contextFunc;
        }

        public void CreateDeliveryAddress(DeliveryAddress address)
        {
            address.DateCreated = DateTime.UtcNow;
            using (var context = contextFunc())
            {
                context.DeliveryAddresses.Add(address);
                context.SaveChanges();
            }
        }
    }
}
