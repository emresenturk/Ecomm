using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Commerce.Data
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }

        public string ERPCode { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxRatio { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ShoppingCartId")]
        public virtual ShoppingCart Cart { get; set; }


        [NotMapped]
        public decimal UnitPriceAfterTax
        {
            get { return Math.Round(UnitPrice*TaxRatio, MidpointRounding.AwayFromZero) + UnitPrice; }
        }

        [NotMapped]
        public decimal TaxAmount
        {
            get { return Math.Round(UnitPrice*Quantity*TaxRatio, MidpointRounding.AwayFromZero); }
        }

        [NotMapped]
        public decimal TotalPriceBeforeTax
        {
            get { return UnitPrice*Quantity; }
        }

        [NotMapped]
        public decimal TotalPrice
        {
            get { return TotalPriceBeforeTax + TaxAmount; }
        }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}