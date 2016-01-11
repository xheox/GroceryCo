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
        /// 
        /// </summary>
        /// <returns></returns>
        ICollection<DiscountConfigurationBase> GetDiscountConfiguration();

        /// <summary>
        /// load all discount rules
        /// example :Plugin pattern: use reflexion to load all teh classes that implment 
        /// "IDiscountRule" and located in a target folder  
        /// </summary>
        /// <returns></returns>
        ICollection<IDiscountRule> BuildDiscountRules();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        bool ValidateDiscountRule(IDiscountRule rule);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
        ICollection<IDiscountRule> ValidateDiscountRules(ICollection<IDiscountRule> rules);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartOrderBase"></param>
        /// <param name="validRules"></param>
        /// <param name="cartLines"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        CartOrderBase ApplyDiscounts(CartOrderBase cartOrderBase, ICollection<IDiscountRule> validRules);
    
    }
}