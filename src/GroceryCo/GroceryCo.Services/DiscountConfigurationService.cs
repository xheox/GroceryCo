using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public bool ValidateConfigurations(ICollection<DiscountConfigurationBase> configurations)
        {
            throw new System.NotImplementedException();
        }
    }
}