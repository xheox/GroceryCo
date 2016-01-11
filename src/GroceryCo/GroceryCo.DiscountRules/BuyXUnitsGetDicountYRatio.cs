using System.Collections.Generic;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.DiscountRules
{
    public class BuyXUnitsGetDicountYRatio : IDiscountRule
    {
        public List<int> ProductList { get; set; }

        public CartOrderBase ApplyDiscount(CartOrderBase cartOrderBase)
        {
            throw new System.NotImplementedException();
        }
    }
}