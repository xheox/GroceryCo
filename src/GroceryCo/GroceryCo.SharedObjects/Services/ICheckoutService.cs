using System.Collections.Generic;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.SharedObjects.Services
{
    public interface ICheckoutService
    {
        CartOrderBase GetCartOrder();
        void DoCheckout();

        CartOrderBase ApplyDiscounts(CartOrderBase order); 
        void PrintReceipt(CartOrderBase order);

    }
}
