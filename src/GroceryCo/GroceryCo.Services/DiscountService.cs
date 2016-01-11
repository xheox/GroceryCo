using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.SharedObjects.Discount;
using GroceryCo.SharedObjects.Services;

namespace GroceryCo.Services
{
    public class DiscountService:IDiscountService
    {
        private readonly IDiscountConfigurationService _configurationService;

        public DiscountService(IDiscountConfigurationService configurationService)
        {
            _configurationService = configurationService;
            
        }

        public DiscountService()
        {
                _configurationService= new DiscountConfigurationService();
        }

        public ICollection<DiscountConfigurationBase> GetDiscountConfiguration()
        {
            try
            {

                var discountConfigs = _configurationService.GetConfiguration();
                return _configurationService.ValidateConfigurations(discountConfigs);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public ICollection<IDiscountRule> BuildDiscountRules()
        {
            var result = new List<IDiscountRule>();
            var validDiscountConfigs = GetDiscountConfiguration();
            foreach (var discountConfigurationBase in validDiscountConfigs)
            {
                var rule = (IDiscountRule)Activator.CreateInstance(discountConfigurationBase.DiscountRuleType,
                    discountConfigurationBase.DiscountRuleParams.ToArray());
                rule.ProductList = discountConfigurationBase.ProductsList.ToList();

                result.Add(rule);
            }
            return result;
        }

        /// <summary>
        /// another level to validate the discount rules provided from the configuration
        /// we assume the configuration is done right and all rules are valid
        /// We could use specification pattern to build a reusable  and chaining for validation rules
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public bool ValidateDiscountRule(IDiscountRule rule)
        {
            return true;
        }

        /// <summary>
        /// we keep only the valid rules
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
        public ICollection<IDiscountRule> ValidateDiscountRules(ICollection<IDiscountRule> rules)
        {
            return rules.Where(ValidateDiscountRule).ToList();
        }

        public CartOrderBase ApplyDiscounts(CartOrderBase cartOrderBase, ICollection<IDiscountRule> validRules)
        {
            foreach (var discountRule in validRules)
            {
                discountRule.ApplyDiscount(cartOrderBase);
            }
            return cartOrderBase;
            
        }
    }
}