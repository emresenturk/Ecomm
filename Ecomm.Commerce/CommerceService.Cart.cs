using System;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public partial class CommerceService
    {
        public void CreateShoppingCart(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public void CreateShoppingCart(string ownerIdentifier)
        {
            throw new NotImplementedException();
        }

        public void MergeShoppingCart(string ownerIdentifier, params Guid[] cartIdentifiers)
        {
            throw new NotImplementedException();
        }

        public bool AddItemToCart(Guid identifier, ShoppingCartItem item)
        {
            throw new NotImplementedException();
        }

        public bool AddItemToCart(string ownerIdentifier, ShoppingCartItem item)
        {
            throw new NotImplementedException();
        }

        public bool ChangeCartItemQuantity(int id, int newQuantity)
        {
            throw new NotImplementedException();
        }

        public bool ChangeCartItemQuantity(string erpCode, int newQuantity)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart RetrieveCart(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart RetrieveCart(string ownerIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}