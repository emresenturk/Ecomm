using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecomm.Commerce.Data;

namespace Ecomm.Commerce
{
    public partial class CommerceService : ICommerceService
    {
        private readonly ICommerceDataContext dataContext;

        public CommerceService(ICommerceDataContext dataContext)
        {
            this.dataContext = dataContext;
        }


    }
}
