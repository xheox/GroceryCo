using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.SharedObjects.Services
{
    /// <summary>
    /// Service to hand the configurations related to discounts settings (by the store manager)
    /// </summary>
    public interface IDiscountConfigurationService
    {
        /// <summary>
        /// This service call will gather the different configurations (DiscountConfigurationBase) 
        /// that may be in the Database, Config File ...
        /// config example : how many discounts we apply at maximum for a given product
        /// in case of multiple discounts , what is the order ....
        /// </summary>
        /// <returns></returns>
        ICollection<DiscountConfigurationBase> GetConfiguration();

        /// <summary>
        /// Method to validate programmatically the configurations : useful 
        /// to mitigate human errors in setting the configuration 
        /// example :  
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        ICollection<DiscountConfigurationBase> ValidateConfigurations(ICollection<DiscountConfigurationBase> configurations);
    }
}