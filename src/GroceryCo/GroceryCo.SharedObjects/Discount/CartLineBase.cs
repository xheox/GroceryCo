using System.Collections.Generic;

namespace GroceryCo.SharedObjects.Discount
{
    /// <summary>
    /// this is the basic order line information structure 
    /// one or more discounts (DiscountItemBase) may apply to each cart line 
    /// </summary>
    public abstract class CartLineBase
    {
        public int ProductId { get; set; }
       public decimal Quantity { get; set; }
       public decimal UnitPrice { get; set; }
       public decimal LinePrice { get; set; }
        
       public decimal LineDiscount { get; set; }

        ICollection<DiscountItemBase> DiscountItems { get; set; }

    }
}