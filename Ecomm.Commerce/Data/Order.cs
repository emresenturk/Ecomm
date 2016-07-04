using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Commerce.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string ReferenceCode { get; set; }

        public string OwnerIdentifier { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}