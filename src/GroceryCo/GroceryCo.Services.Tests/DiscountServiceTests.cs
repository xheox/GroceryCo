using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Data.Entities;
using GroceryCo.DiscountRules;
using GroceryCo.SharedObjects.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryCo.Services.Tests
{
    [TestClass]
    public class DiscountServiceTests
    {
        [TestMethod]
        public void GetDiscountConfigsRulesFromService()
        {
            var svc = new DiscountConfigurationService();

            var configs = svc.GetConfiguration();

            Assert.AreEqual(configs.Count, 4);
        }

        [TestMethod]
        public void BuildDiscountRules()
        {

            var rules = new List<IDiscountRule>();
            var configurationService = new DiscountConfigurationService();
            var discountConfigs = configurationService.GetConfiguration();
            var validDiscountConfigs = configurationService.ValidateConfigurations(discountConfigs);
             
            foreach (var discountConfigurationBase in validDiscountConfigs)
            {
                var rule = (IDiscountRule)Activator.CreateInstance(discountConfigurationBase.DiscountRuleType, discountConfigurationBase.DiscountRuleParams.ToArray());
                rule.ProductList = discountConfigurationBase.ProductsList.ToList();

                rules.Add(rule);
            }

            Assert.AreEqual(rules.Count, 3);
        }

        [TestMethod]
        public void BuildDiscountRulesFromService()
        {

            var rules = new DiscountService().BuildDiscountRules();
            Assert.AreEqual(rules.Count, 3);
        }


        [TestMethod]
        public void ApplyRule_BuyProductXGetFreeProductY_SingleItem()
        {
            //var order = new CheckoutService().GetCartOrder();
            var item= new CartLine
                      {
                          ProductId = 1,
                          Quantity = 1,
                          UnitPrice = 50,
                          LineDiscount = 0,
                          LinePrice = 50,
                      };
            var rule = new BuyProductXGetFreeProductY(1,4)
                       {
                           ProductList = new List<int>{1,3}
                       };
            // apply discount
            CartLine free= new CartLine();
            if (rule._boughtProdId==item.ProductId)
            {
                free = new CartLine()
                           {
                               ProductId = rule._offeredProdId,
                               Quantity = 1,
                               LinePrice = 0,
                               UnitPrice = 0,
                               LineDiscount = 0
                           };
            }

            Assert.AreEqual(free.ProductId,4);
        }

        [TestMethod]
        public void ApplyRules_BuyProductXGetFreeProductY_MultipleCartItems()
        {
            var order = new CheckoutService().GetCartOrder();
           var rules =new DiscountService().BuildDiscountRules();
            var free = new CartLine();
            foreach (BuyProductXGetFreeProductY rule in rules)
            {
                foreach (var cartLine in order.CartLines)
                {
                    if (rule._boughtProdId == cartLine.ProductId)
                    {
                        free = new CartLine()
                        {
                            ProductId = rule._offeredProdId,
                            Quantity = 1,
                            LinePrice = 0,
                            UnitPrice = 0,
                            LineDiscount = 0
                        };
                        order.GivenProducts.Add(free);
                    }
                }
            }
            
            var count = order.GivenProducts.Count(i => i.ProductId == 3);

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ApplyRules_BuyXUnitsGetFreeYUnits_MultipleCartItems()
        {
            var order = new CheckoutService().GetCartOrder();
            
            var rules = GetRules();
            var free = new CartLine();
            foreach (BuyXUnitsGetFreeYUnits rule in rules)
            {
                if ( rule._boughtQuantity != 0 && rule._freeQuantity!=0)
                {
                    
                    foreach (var cartLine in order.CartLines)
                    {
                        var div = (int)(cartLine.Quantity/rule._boughtQuantity);
                        if (rule.ProductList.Contains(cartLine.ProductId) && cartLine.Quantity>rule._boughtQuantity)
                        {
                            cartLine.LinePrice -= div*rule._freeQuantity * cartLine.UnitPrice;
                            
                        }
                    }
                }
            }

            var prodLine = order.CartLines.FirstOrDefault(i => i.ProductId == 4);

            Assert.AreEqual(prodLine.LinePrice, (decimal)183.92);
        }

        private List<IDiscountRule> GetRules()
        {

            return new List<IDiscountRule>()
                         {
                             new BuyXUnitsGetFreeYUnits(2,1)
                             {
                                 ProductList = new List<int>(){1,3}
                             },
                             new BuyXUnitsGetFreeYUnits(5,1)
                             {
                                 ProductList = new List<int>{4}
                             },

                         };
            
        }
    }

   
}
