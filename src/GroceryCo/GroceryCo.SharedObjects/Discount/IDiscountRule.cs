namespace GroceryCo.SharedObjects.Discount
{
    /// <summary>
    /// base type for Discount Rules
    /// possible sub classes :
        // buy x units get free y units, 
        // buy x units discount y %, 
        //buy product x get product y,
        //buy x$ get discount y%.
    ///  </summary>
    public interface IDiscountRule
    {
        DiscountItemBase ApplyDiscount(CartLineBase cartLineBase);
    }
}
