using System.Collections.Generic;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.SharedObjects.Services
{
    /// <summary>
    /// the main service for calculating the discounts based on the cart items 
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// load all discount rules
        /// example :Plugin pattern: use reflexion to load all teh classes that implment 
        /// "IDiscountRule" and located in a target folder  
        /// </summary>
        /// <returns></returns>
        ICollection<IDiscountRule> GetDiscountRules();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
        bool ValidateDiscountRules(ICollection<IDiscountRule> rules);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartLines"></param>
        /// <param name="configurationService"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        ICollection<DiscountItemBase> ApplyDiscounts(ICollection<CartLineBase> cartLines,
            IDiscountConfigurationService configurationService, ICollection<IDiscountRule> rules);

    }
}