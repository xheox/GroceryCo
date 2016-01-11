using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.Data.Entities
{
    public class CartOrder : CartOrderBase
    {
        public CartOrder()
        {
            CartLines = new List<CartLineBase>();
            GivenProducts = new List<CartLineBase>();
        }
        // some additional fields beside the ones inherited
        public string Code { get; set; }

        public string ShipTo { get; set; }
        public decimal TotalBeforeTax { get; set; }
        public decimal TotalAfterTax { get; set; }
        public decimal TotalTax { get; set; }

    }
}
