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
    public class CheckoutServiceTests
    {

        
        [TestMethod]
        public void GetDiscountConfigsRulesFromService()
        {
            var svc = new DiscountConfigurationService();

            var configs = svc.GetConfiguration();

            Assert.AreEqual(configs.Count,4);
        }

        [TestMethod]
        public void ValidateDiscountConfigsRulesFromService()
        {
            var svc = new DiscountConfigurationService();

            var configs = svc.GetConfiguration();

            var validConfigs = svc.ValidateConfigurations(configs);

            Assert.AreEqual(validConfigs.Count, 3);
        }

        [TestMethod]
        public void AggregateCartOrder()
        {
            var order = new CartOrder
            {
                ID = 1,
                Code = "ORDER01",
                OrderDate = DateTime.Now,
                CartLines = new List<CartLineBase>
                                        {
                                            new CartLine
                                            {
                                                ProductId = 1,
                                                LineDiscount = 10,
                                                UnitPrice = 15,
                                                Quantity = 1,
                                            },
                                            new CartLine
                                            {
                                                ProductId = 2,
                                                LineDiscount = 0,
                                                UnitPrice = 28,
                                                Quantity = 3,
                                            },
                                            new CartLine
                                            {
                                                ProductId = 1,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 18.75,
                                                Quantity = 6,
                                            },
                                            new CartLine
                                            {
                                                ProductId = 2,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 22.99,
                                                Quantity = 10,
                                            },
                                        }
            };

            order = (CartOrder)AggregateOrderLines(order);
            var first = order.CartLines.FirstOrDefault();


            Assert.AreEqual(first.Quantity,7);
        }
        private CartOrderBase AggregateOrderLines(CartOrderBase order)
        {
            var result= new List<CartLineBase>();
            var distinctProds = order.CartLines.Select(l => l.ProductId).Distinct();
            foreach (var prodId in distinctProds)
            {
                var itemLine = order.CartLines.FirstOrDefault(i=>i.ProductId==prodId);
                if (itemLine != null)
                {
                    itemLine.Quantity = order.CartLines.Where(i=>i.ProductId==itemLine.ProductId).Sum(l => l.Quantity);
                    itemLine.LinePrice = order.CartLines.Where(i => i.ProductId == itemLine.ProductId).Sum(l => l.LinePrice);
                    itemLine.LineDiscount = order.CartLines.Where(i => i.ProductId == itemLine.ProductId).Sum(l => l.LineDiscount);
                    result.Add(itemLine);

                }
            }
            var cartLines = order.CartLines.ToList();
            order.CartLines = result;
            return order;
        }


    }
}
