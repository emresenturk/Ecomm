namespace Ecomm.Catalog.Providers
{
    public interface ICatalogDataProviderFactory
    {

        ICatalogDataProvider CreateProvider();
    }
}