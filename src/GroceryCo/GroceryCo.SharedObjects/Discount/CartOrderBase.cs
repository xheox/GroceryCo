using System;
using System.Collections.Generic;

namespace GroceryCo.SharedObjects.Discount
{
    public class CartOrderBase
    {
        
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public ICollection<CartLineBase> CartLines { get; set; }

        // in case of free item given : buy product x get a free product y.
        public ICollection<CartLineBase> GivenProducts { get; set; }
    }
}
