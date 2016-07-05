using System;
using System.Configuration;
using System.Linq;
using Ecomm.Catalog.Providers;

namespace Ecomm.Catalog.DataProviders.Xml
{
    public class XmlCatalogDataProdivderFactory : ICatalogDataProviderFactory
    {
        private readonly string filename;

        public XmlCatalogDataProdivderFactory()
        {
            filename =
                ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>()
                    .FirstOrDefault(css => css.ProviderName == "Ecomm.Catalog.DataProviders.Xml")
                    .ConnectionString;
        }

        public ICatalogDataProvider CreateProvider()
        {
            return new XmlCatalogDataProvider(filename);
        }
    }
}
