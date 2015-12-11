using GroceryCo.SharedObjects.Discount;

namespace GroceryCo.Data.Entities
{
    public class CartLine : CartLineBase
    {
        decimal Tax { get; set; }
        decimal TaxRatio { get; set; }

        decimal ShippingCost { get; set; }

        decimal LinePriceAfterTax { get; set; }


    }
}