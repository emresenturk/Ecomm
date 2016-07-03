using System.Collections.Generic;
using Ecomm.Catalog.Data;

namespace Ecomm.Catalog
{
    class CatalogService : ICatalogService
    {
        public IEnumerable<Product> ReadProducts()
        {
            throw new System.NotImplementedException();
        }

        public IList<Product> ListProducts(int? @from, int? to)
        {
            throw new System.NotImplementedException();
        }

        public Product RetrieveProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product RetrieveProduct(string erpCode)
        {
            throw new System.NotImplementedException();
        }
    }
}