using System;
using System.Collections.Generic;
using System.Linq;
using Ecomm.Catalog.Data;
using Ecomm.Catalog.Providers;

namespace Ecomm.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogDataProviderFactory dataProviderFactory;

        public CatalogService(ICatalogDataProviderFactory dataProviderFactory)
        {
            this.dataProviderFactory = dataProviderFactory;
        }

        public IEnumerable<Product> ReadProducts()
        {
            using (var provider = dataProviderFactory.CreateProvider())
            {
                foreach (var product in provider.CreateQuery())
                {
                    yield return product;
                }
            }
        }

        public IList<Product> ListProducts(int? @from, int? to, string searchExpression)
        {
            IList<Product> products;

            using (var provider = dataProviderFactory.CreateProvider())
            {
                var query = provider.CreateQuery();
                if (!string.IsNullOrEmpty(searchExpression))
                {
                    query =
                        query.Where(
                            p => p.Name.Contains(searchExpression) || p.ShortDescription.Contains(searchExpression));
                }

                if (@from.HasValue)
                {
                    query = query.Skip(@from.Value);
                }

                if (to.HasValue)
                {
                    query = query.Take(to.Value - @from.GetValueOrDefault());
                }

                products = query.ToList();
            }

            return products;
        }

        public Product RetrieveProduct(int id)
        {
            Product product;
            using (var provider = dataProviderFactory.CreateProvider())
            {
                product = provider.CreateQuery().FirstOrDefault(p => p.Id == id);
            }

            return product;
        }

        public Product RetrieveProduct(string erpCode)
        {
            if (string.IsNullOrEmpty(erpCode))
            {
                throw new ArgumentNullException("erpCode", "Invalid ERP Code!");
            }

            Product product;
            using (var provider = dataProviderFactory.CreateProvider())
            {
                product = provider.CreateQuery().FirstOrDefault(p => p.ERPCode == erpCode);
            }

            return product;
        }
    }
}