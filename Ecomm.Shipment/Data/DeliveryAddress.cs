using System;

namespace Ecomm.Shipment.Data
{
    public class DeliveryAddress
    {
        public int Id { get; set; }

        public string ReferenceCode { get; set; }

        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HouseNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}