namespace GroceryCo.SharedObjects.Discount
{
    /// <summary>
    /// result of discount service for each Cart item
    /// Description :  the label to be printed on the receipt
    /// Amount  : the discount amount applied on the cart item
    /// </summary>
    public abstract class DiscountItemBase
    {
        string Description { get; set; }
        decimal DiscountAmount { get; set; }
    }
}