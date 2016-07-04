using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Commerce.Data
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string ERPCode { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxRatio { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}