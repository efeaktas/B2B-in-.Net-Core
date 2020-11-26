using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Utilities
{
    public class ClientUrlConstants
    {
        public const string UpdateDealerUrl = "/Client/Settings/UpdateDealer";
        public const string UpdateDealerPasswordUrl = "/Client/Settings/UpdatePassword";

        public const string CreateCustomerUrl = "/Client/Customer/CreateCustomer";
        public const string UpdateCustomerUrl = "/Client/Customer/UpdateCustomer";
        public const string DeleteCustomerUrl = "/Client/Customer/DeleteCustomer";

        public const string CreateSaleUrl = "/Client/Sale/CreateSale";
        public const string DeleteSaleUrl = "/Client/Sale/DeleteSale";

        public const string CreateOrderUrl = "/Client/Order/CreateOrder";
        public const string DeleteOrderUrl = "/Client/Order/DeleteOrder";
    }
}
