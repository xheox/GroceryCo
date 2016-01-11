using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.DiscountRules
{
    public class BuyXUnitsGetFreeYUnits : IDiscountRule
    {
        public readonly decimal _boughtQuantity;
        public readonly decimal _freeQuantity;

        public List<int> ProductList { get; set; }

        public BuyXUnitsGetFreeYUnits(decimal boughtQuantity, decimal freeQuantity)
        {
            _boughtQuantity = boughtQuantity;
            _freeQuantity = freeQuantity;
        }

        public BuyXUnitsGetFreeYUnits(List<decimal> paramsList)
        {
            _boughtQuantity = (decimal)paramsList.ElementAt(0);
            _freeQuantity = (decimal)paramsList.ElementAt(1);
        }

        public CartOrderBase ApplyDiscount(CartOrderBase cartOrderBase)
        {
            if (_boughtQuantity != 0 && _freeQuantity != 0)
            {

                foreach (var cartLine in cartOrderBase.CartLines)
                {
                    var div = (int)(cartLine.Quantity / _boughtQuantity);
                    if (ProductList.Contains(cartLine.ProductId) && cartLine.Quantity > _boughtQuantity)
                    {
                        cartLine.LinePrice -= div * _freeQuantity * cartLine.UnitPrice;

                    }
                }
            }
            return cartOrderBase;
        }
    }
}
