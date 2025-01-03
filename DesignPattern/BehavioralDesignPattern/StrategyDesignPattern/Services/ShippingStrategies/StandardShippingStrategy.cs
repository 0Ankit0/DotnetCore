using StrategyDesignPattern.Models;

namespace StrategyDesignPattern.Services.ShippingStrategies
{
    public class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(Order order)
        {
            // Example: Flat rate plus a small fee per item
            var baseCost = 5.00m;
            var perItemCost = 1.00m * order.ItemCount;
            return baseCost + perItemCost;
        }
    }
}
