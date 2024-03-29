﻿using System;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public interface ICommerceService
    {
        #region Cart

        void CreateShoppingCart(Guid identifier);

        void CreateShoppingCart(string ownerIdentifier);

        void MergeShoppingCart(string ownerIdentifier, params Guid[] cartIdentifiers);

        bool AddItemToCart(Guid identifier, ShoppingCartItem item);

        bool AddItemToCart(string ownerIdentifier, ShoppingCartItem item);

        bool ChangeCartItemQuantity(int id, int newQuantity);

        ShoppingCart RetrieveCart(Guid identifier);

        ShoppingCart RetrieveCart(string ownerIdentifier);

        #endregion

        #region Order

        Order CreateOrder(Guid cartIdentifier);

        Order CreateOrder(string ownerIdentifier);

        Order RetrieveOrder(string referenceCode);

        #endregion


    }
}