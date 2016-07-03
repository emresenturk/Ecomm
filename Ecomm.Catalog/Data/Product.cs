namespace Ecomm.Catalog.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string ERPCode { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxRatio { get; set; }
    }
}
