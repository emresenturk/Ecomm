using System;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public interface ICommerceService
    {
        void CreateShoppingCart(Guid identifier);

        void CreateShoppingCart(string ownerIdentifier);

        void MergeShoppingCart(string ownerIdentifier, params Guid[] cartIdentifiers);

        bool AddItemToCart(Guid identifier, ShoppingCartItem item);

        bool AddItemToCart(string ownerIdentifier, ShoppingCartItem item);

        bool ChangeCartItemQuantity(int id, int newQuantity);

        bool ChangeCartItemQuantity(string erpCode, int newQuantity);

        ShoppingCart RetrieveCart(Guid identifier);

        ShoppingCart RetrieveCart(string ownerIdentifier);
    }
}