using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Utilities
{
    public class AdminUrlConstants
    {
        public const string UpdatePasswordByEmailUrl = "/Account/ResetPassword";
        public const string UserLoginUrl = "/Account/UserLogin";

        public const string UpdatePasswordUrl = "/Admin/Settings/UpdateForPassword";
        public const string UpdateAdminUrl = "/Admin/Settings/UpdateAdmin";

        public const string CreateDealerUrl = "/Admin/Dealer/CreateDealer";
        public const string UpdateDealerUrl = "/Admin/Dealer/UpdateDealer";
        public const string DeleteDealerUrl = "/Admin/Dealer/DeleteDealer";

        public const string CreateProductUrl = "/Admin/Product/CreateProduct";
        public const string StockProductUrl = "/Admin/Product/StockProduct";

        public const string SubtractStockProductUrl = "/Admin/Product/SubtractStockProduct";
        public const string UpdateProductUrl = "/Admin/Product/UpdateProduct";
        public const string DeleteProductUrl = "/Admin/Product/DeleteProduct";

        public const string CreateSaleUrl = "/Admin/Sale/CreateSale";
        public const string UpdateSaleUrl = "/Admin/Sale/UpdateSale";
        public const string DeleteSaleUrl = "/Admin/Sale/DeleteSale";
    }
}
