using System.Collections.Generic;
using Ecomm.Catalog.Data;

namespace Ecomm.Catalog
{
    public interface ICatalogService
    {
        IEnumerable<Product> ReadProducts();

        IList<Product> ListProducts(int? @from, int? to, string searchExpression);

        Product RetrieveProduct(int id);

        Product RetrieveProduct(string erpCode);
    }
}