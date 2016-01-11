using System;
using System.Collections.Generic;
using GroceryCo.Data.Entities;
using GroceryCo.DiscountRules;
using GroceryCo.SharedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.Data.Tests
{
    [TestClass]
    public class DataTests
    {
       

        [TestMethod]
        public void Generate1CartLine()
        {
            var item = new CartLine
            {
                ProductId = 1,
                LineDiscount = 10,
                UnitPrice = 15,
                Quantity = 1,
            };


            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void GenerateMultipleCartLine()
        {

            var items = new List<CartLine>
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
                                                ProductId = 3,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 18.75,
                                                Quantity = 6,
                                            },
                                            new CartLine
                                            {
                                                ProductId = 4,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 22.99,
                                                Quantity = 10,
                                            },
                        };


            Assert.AreEqual(items.Count,4);
        }

        [TestMethod]
        public void Generate1CartOrder()
        {
            var order = new CartOrder
                        {
                            ID = 1,
                            Code = "ORDER01",
                            OrderDate = DateTime.Now,
                            CartLines =  new List<CartLineBase>
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
                                                ProductId = 3,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 18.75,
                                                Quantity = 6,
                                            },
                                            new CartLine
                                            {
                                                ProductId = 4,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 22.99,
                                                Quantity = 10,
                                            },
                                        }
                        };


            Assert.IsNotNull(order);
        }
    }
}
