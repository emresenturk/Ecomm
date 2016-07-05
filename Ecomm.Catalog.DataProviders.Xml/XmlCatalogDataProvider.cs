using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Xml.Serialization;
using Ecomm.Catalog.Data;
using Ecomm.Catalog.Providers;

namespace Ecomm.Catalog.DataProviders.Xml
{
    public class XmlCatalogDataProvider : ICatalogDataProvider
    {
        private string xmlFileName;
        private XElement root;

        public XmlCatalogDataProvider(string xmlFileName)
        {
            this.xmlFileName = xmlFileName;
            root = XElement.Load(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), xmlFileName));
        }

        public int Count()
        {
            var products = root.Descendants("Products").First();
            return products.Descendants().Where(d => d.Parent == products).Count();
        }

        public int Count(Expression<Func<Product, bool>> expression)
        {
            var predicate = expression.Compile();
            var products = root.Descendants("Products").First();
            var count = products.Descendants().Where(d => d.Parent == products).Count(x => predicate(x.ToProduct()));
            return count;
        }

        public IQueryable<Product> CreateQuery()
        {
            return root.Descendants("Product").Select(d => d.ToProduct()).AsQueryable();
        }

        public void Dispose()
        {
        }
    }
}