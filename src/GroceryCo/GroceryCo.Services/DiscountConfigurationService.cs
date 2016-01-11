using System.Collections.Generic;
using System.Linq;
using GroceryCo.DiscountRules;
using GroceryCo.SharedObjects.Discount;
using GroceryCo.SharedObjects.Services;

namespace GroceryCo.Services
{
    /// <summary>
    /// Actual implementation of the service
    /// </summary>
    public class DiscountConfigurationService : IDiscountConfigurationService
    {
        public ICollection<DiscountConfigurationBase> GetConfiguration()
        {
            return
                new List<DiscountConfigurationBase>
                       {
                           new DiscountConfigurationBase
                           {
                               ConfigName = "Config1",
                               ApplyToOrder = false,
                               ProductsList = new List<int> {1, 2},
                               DiscountRuleType = typeof (BuyProductXGetFreeProductY),
                               DiscountRuleParams =
                                   new List<object>
                                   {
                                       3,
                                       1
                                   },
                           },
                           new DiscountConfigurationBase
                           {
                               ConfigName = "Config2",
                               ApplyToOrder = true,
                               ProductsList = new List<int> {2},
                               DiscountRuleType = typeof (BuyProductXGetFreeProductY),
                               DiscountRuleParams = new List<object>
                                                    {
                                                        2,
                                                        3
                                                    },
                           },
                           new DiscountConfigurationBase
                           {
                               ConfigName = "Config3",
                               ApplyToOrder = false,
                               ProductsList = new List<int> { 3},
                               DiscountRuleType = typeof (BuyProductXGetFreeProductY),
                               DiscountRuleParams =
                                   new List<object>
                                   {
                                       3,
                                       1
                                   },



                           },
                           new DiscountConfigurationBase
                           {
                               ConfigName = "Config4",
                               ApplyToOrder = true,
                               ProductsList = new List<int> (),
                               DiscountRuleType = typeof (BuyProductXGetFreeProductY),
                               DiscountRuleParams = new List<object>(),
                           },
                       };

            
        }
        /// <summary>
        /// Validation of configs and return only the valid configurations
        /// for example we take only rules with non empty product list.
        /// We Could use Specification pattern to compose validation criteria 
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public ICollection<DiscountConfigurationBase> ValidateConfigurations(ICollection<DiscountConfigurationBase> configurations)
        {
            return configurations.Where(cfg => cfg.ProductsList.Any()).ToList();
        }
    }
}