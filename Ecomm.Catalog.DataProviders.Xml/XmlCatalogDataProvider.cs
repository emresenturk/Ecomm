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
            root = new XElement(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), xmlFileName));
        }

        public int Count()
        {
            return root.Descendants().Count();
        }

        public int Count(Expression<Func<Product, bool>> expression)
        {
            var predicate = expression.Compile();
            return root.Descendants().Count(x => predicate(x.ToProduct()));
        }

        public IQueryable<Product> CreateQuery()
        {
            return root.Descendants().Select(d => d.ToProduct()).AsQueryable();
        }

        public void Dispose()
        {
        }
    }
}