namespace ShoppingCartTDDAssignmentLib
{

    public class Checkout
    {
        private PriceRules priceRules;

        public Checkout(PriceRules priceRules)
        {
            this.priceRules = priceRules;
        }

        public int GetTotal(string checkoutItems)
        {
            return priceRules.CalculateTotal(checkoutItems);
        }
    }
}
