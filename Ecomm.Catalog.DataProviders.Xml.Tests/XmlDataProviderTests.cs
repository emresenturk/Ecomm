using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecomm.Catalog.Providers;
using Xunit;

namespace Ecomm.Catalog.DataProviders.Xml.Tests
{
    public class XmlDataProviderTests : IDisposable
    {
        private readonly ICatalogDataProviderFactory xmlDataProviderFactory;

        public XmlDataProviderTests()
        {
            xmlDataProviderFactory = new XmlCatalogDataProdivderFactory();
        }

        [Fact(DisplayName = @"Factory can create a new provider")]
        public void Factory_can_create_a_new_provider()
        {
            using (var provider = xmlDataProviderFactory.CreateProvider())
            {
                Assert.NotNull(provider);
            }
        }

        [Fact(DisplayName = @"Provider can count products")]
        public void Provider_can_count_products()
        {
            using (var provider = xmlDataProviderFactory.CreateProvider())
            {
                Assert.NotEqual(0, provider.Count());

                Assert.NotEqual(0, provider.Count(p => p.ERPCode == "SP1234"));

                Assert.NotEqual(0, provider.Count(p => p.Name.StartsWith("Some")));

                Assert.Equal(0, provider.Count(p => p.TaxRatio == 0m));
            }
        }

        public void Dispose()
        {
        }
    }
}
