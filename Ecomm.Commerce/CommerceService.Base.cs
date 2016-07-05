using System;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public partial class CommerceService : ICommerceService
    {
        private readonly Func<ICommerceDataContext> contextFunc;

        public CommerceService(Func<ICommerceDataContext> contextFunc)
        {
            this.contextFunc = contextFunc;
        }


    }
}
