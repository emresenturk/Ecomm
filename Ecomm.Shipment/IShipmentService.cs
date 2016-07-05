using Ecomm.Shipment.Data;

namespace Ecomm.Shipment
{
    public interface IShipmentService
    {
        void CreateDeliveryAddress(DeliveryAddress address);
    }
}