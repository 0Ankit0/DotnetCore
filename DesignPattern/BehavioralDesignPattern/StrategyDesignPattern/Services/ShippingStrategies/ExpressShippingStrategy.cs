using StrategyDesignPattern.Models;

namespace StrategyDesignPattern.Services.ShippingStrategies
{
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(Order order)
        {
            // Example: Higher flat rate, slightly cheaper cost per item
            var baseCost = 12.00m;
            var perItemCost = 0.50m * order.ItemCount;
            return baseCost + perItemCost;
        }
    }
}
