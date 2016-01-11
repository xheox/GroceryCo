using System;
using System.Collections.Generic;
using GroceryCo.DiscountRules;
using GroceryCo.SharedObjects.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryCo.Services.Tests
{
    [TestClass]
    public class DiscountConfigServiceTests
    {
        [TestMethod]
        public void Generate1DiscountConfigRule()
        {
            var cfg = new DiscountConfigurationBase
                      {
                          ConfigName = "Name of Config or ID",
                          ApplyToOrder = false,
                          ProductsList = new List<int> {1, 2, 3},
                          DiscountRuleType = typeof (BuyProductXGetFreeProductY),
                          DiscountRuleParams = new List<object>
                                               {
                                                   1,
                                                   3
                                               },

                      };

            Assert.IsNotNull(cfg);
        }

        [TestMethod]
        public void GenerateDiscountConfigsRules()
        {
            var list = new List<DiscountConfigurationBase>
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
                                       1,
                                       3
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
                               ProductsList = new List<int> {1, 2, 3},
                               DiscountRuleType = typeof (BuyProductXGetFreeProductY),
                               DiscountRuleParams =
                                   new List<object>
                                   {
                                       3,
                                       1
                                   },



                           },
                       };


            Assert.AreEqual(list.Count, 3);
        }

    }
}
