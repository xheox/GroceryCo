using System.Collections.Generic;

namespace GroceryCo.SharedObjects.Discount
{
    /// <summary>
    /// this is the basic order line information structure 
    /// one or more discounts (DiscountItemBase) may apply to each cart line 
    /// </summary>
    public abstract class CartLineBase
    {
        string ProductId { get; set; }
        decimal Quantity { get; set; }
        decimal UnitPrice { get; set; }
        decimal LinePrice { get; set; }

        decimal LineDiscount { get; set; }

        ICollection<DiscountItemBase> DiscountItems { get; set; }

    }
}