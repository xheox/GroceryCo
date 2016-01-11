using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.Data.Entities;
using GroceryCo.SharedObjects.Discount;
using GroceryCo.SharedObjects.Services;

namespace GroceryCo.Services
{
    public class CheckoutService : ICheckoutService
    {
       
        private readonly IDiscountService _discountService;

        public CheckoutService( IDiscountService discountService)
        {
            
            _discountService = discountService;
        }

        public CheckoutService()
        {
           
            _discountService = new DiscountService();
        }


        /// <summary>
        /// get the order to be processed from the cart/ DB/ Session 
        /// </summary>
        /// <returns></returns>
        public CartOrderBase GetCartOrder()
        {
            try
            {
                return BuildOrder();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DoCheckout()
        {
            var order = GetCartOrder();
            order= AggregateOrderLines(order);
            var result = ApplyDiscounts(order);
            PrintReceipt(result);
        }

        /// <summary>
        /// aggregate lines having same products 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private CartOrderBase AggregateOrderLines(CartOrderBase order)
        {
            var result = new List<CartLineBase>();
            var distinctProds = order.CartLines.Select(l => l.ProductId).Distinct();
            foreach (var prodId in distinctProds)
            {
                var itemLine = order.CartLines.FirstOrDefault(i => i.ProductId == prodId);
                if (itemLine != null)
                {
                    itemLine.Quantity = order.CartLines.Where(i => i.ProductId == itemLine.ProductId).Sum(l => l.Quantity);
                    itemLine.LinePrice = order.CartLines.Where(i => i.ProductId == itemLine.ProductId).Sum(l => l.LinePrice);
                    itemLine.LineDiscount = order.CartLines.Where(i => i.ProductId == itemLine.ProductId).Sum(l => l.LineDiscount);
                    result.Add(itemLine);

                }
            }
            var cartLines = order.CartLines.ToList();
            order.CartLines = result;
            return order;
        }
        public CartOrderBase BuildOrder()
        {
            return new CartOrder
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
                                                LinePrice = 5
                                            },
                                            new CartLine
                                            {
                                                ProductId = 2,
                                                LineDiscount = 0,
                                                UnitPrice = 28,
                                                Quantity = 3,
                                                LinePrice = 54,
                                            },
                                            new CartLine
                                            {
                                                ProductId = 3,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 18.75,
                                                Quantity = 6,
                                                LinePrice = (decimal)112.5
                                            },
                                            new CartLine
                                            {
                                                ProductId = 4,
                                                LineDiscount = 0,
                                                UnitPrice = (decimal) 22.99,
                                                Quantity = 10,
                                                LinePrice = (decimal)229.9
                                            },
                                        }
            };
        }

        

        public CartOrderBase ApplyDiscounts(CartOrderBase order)
        {
            
            try
            {
                var discountRules = _discountService.BuildDiscountRules();
                var validRules = _discountService.ValidateDiscountRules(discountRules);
                return _discountService.ApplyDiscounts(order, validRules);

            }
            catch (Exception)
            {
                throw new Exception(" ApplyDiscounts ");
            }

        }

        public void PrintReceipt(CartOrderBase order)
        {
            Console.Clear();
            Console.WriteLine("Receipt for Order :" + order.ID);
            Console.WriteLine("########################################");
            Console.WriteLine("############    Receipt    #############");
            Console.WriteLine("########################################");
            foreach (var cartLineBase in order.CartLines)
            {
                Console.WriteLine(
                    $"Product:  {cartLineBase.ProductId} {cartLineBase.UnitPrice} * {cartLineBase.Quantity}  = {cartLineBase.LinePrice}");
            }

        }
    }
}
