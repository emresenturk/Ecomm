using System;
using System.Xml.Linq;
using Ecomm.Catalog.Data;

namespace Ecomm.Catalog.DataProviders.Xml
{
    internal static class XElementExtensions
    {
        internal static Product ToProduct(this XElement source)
        {
            var product = new Product
            {
                Id = Convert.ToInt32(source.Element("Id").Value),
                ERPCode = source.Element("ERPCode").Value,
                LongDescription = source.Element("LongDescription").Value,
                ShortDescription = source.Element("ShortDescription").Value,
                Name = source.Element("Name").Value,
                TaxRatio = Convert.ToDecimal(source.Element("TaxRatio").Value),
                UnitPrice = Convert.ToDecimal(source.Element("UnitPrice").Value)
            };

            return product;
        }
    }
}