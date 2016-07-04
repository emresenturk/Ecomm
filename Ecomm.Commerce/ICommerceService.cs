using System;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public interface ICommerceService
    {
        bool AddItemToCart(ShoppingCartItem item);

        bool ChangeCartItemQuantity(int id, int newQuantity);

        bool ChangeCartItemQuantity(string erpCode, int newQuantity);

        ShoppingCart RetrieveCart(Guid identifier);

        ShoppingCart RetrieveCart(string ownerIdentifier);
    }
}