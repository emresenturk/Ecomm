using System;
using System.Linq;
using System.Linq.Expressions;
using Ecomm.Catalog.Data;
using Ecomm.Catalog.Providers;

namespace Ecomm.Catalog.DataProviders.Xml
{
    public class XmlCatalogDataProvider : ICatalogDataProvider
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> CreateQuery()
        {
            throw new NotImplementedException();
        }
    }
}