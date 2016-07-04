using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ecomm.Commerce.Data
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public string OwnerIdentifier { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get { return Items.Sum(i => i.TotalPrice); }
        }

        [NotMapped]
        public decimal TotalPriceBeforeTax
        {
            get { return Items.Sum(i => i.TotalPriceBeforeTax); }
        }

        [NotMapped]
        public decimal TaxAmount
        {
            get { return Items.Sum(i => i.TaxAmount); }
        }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}