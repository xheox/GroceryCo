using System.Collections.Generic;
using GroceryCo.SharedObjects.Discount;
using GroceryCo.SharedObjects.Services;

namespace GroceryCo.Services
{
    public class DiscountService:IDiscountService
    {
        public ICollection<IDiscountRule> GetDiscountRules()
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateDiscountRules(ICollection<IDiscountRule> rules)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<DiscountItemBase> ApplyDiscounts(ICollection<CartLineBase> cartLines, IDiscountConfigurationService configurationService, ICollection<IDiscountRule> rules)
        {
            throw new System.NotImplementedException();
        }
    }
}