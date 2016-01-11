using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GroceryCo.SharedObjects.Discount
{
    public class DiscountConfigurationBase
    {
        public DiscountConfigurationBase()
        {
            DiscountRuleParams = new List<object>();
        }
        public string ConfigName { get; set; }
        public bool ApplyToOrder { get; set; }

        public ICollection<int> ProductsList { get; set; }

        public Type DiscountRuleType { get; set; }

        public List<object> DiscountRuleParams { get; set; }

    }
}