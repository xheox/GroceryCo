using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.DiscountRules
{
    class BuyXUnitsGetFreeYUnits : IDiscountRule
    {
        public DiscountItemBase ApplyDiscount(CartLineBase cartLineBase)
        {
            throw new NotImplementedException();
        }
    }
}
