using System.Collections.Generic;
using System.Linq;
using GroceryCo.Data.Entities;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.DiscountRules
{
    public class BuyProductXGetFreeProductY:IDiscountRule
    {
        public readonly int _boughtProdId;
        public readonly int _offeredProdId;

        public BuyProductXGetFreeProductY(int boughtProdId, int offeredProdId)
        {
            _boughtProdId = boughtProdId;
            _offeredProdId = offeredProdId;
        }
        public BuyProductXGetFreeProductY(List<int> paramsList )
        {
            _boughtProdId = paramsList.ElementAt(0);
            _offeredProdId = paramsList.ElementAt(1);
        }

        public List<int> ProductList { get; set; }

        /// <summary>
        /// for each 
        /// </summary>
        /// <param name="cartOrderBase"></param>
        /// <returns></returns>
        public CartOrderBase ApplyDiscount(CartOrderBase order)
        {
            var free = new CartLine();
            foreach (var cartLine in order.CartLines)
            {
                if (_boughtProdId == cartLine.ProductId)
                {
                    free = new CartLine()
                    {
                        ProductId = _offeredProdId,
                        Quantity = 1,
                        LinePrice = 0,
                        UnitPrice = 0,
                        LineDiscount = 0
                    };
                    order.GivenProducts.Add(free);
                }
            }
            return order;
        }

        
    }
}