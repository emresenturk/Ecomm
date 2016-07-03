using System;
using System.Linq;
using System.Linq.Expressions;
using Ecomm.Catalog.Data;

namespace Ecomm.Catalog.Providers
{
    public interface ICatalogDataProvider : IDisposable
    {
        int Count();

        int Count(Expression<Func<Product, bool>> expression);

        IQueryable<Product> CreateQuery();
    }
}