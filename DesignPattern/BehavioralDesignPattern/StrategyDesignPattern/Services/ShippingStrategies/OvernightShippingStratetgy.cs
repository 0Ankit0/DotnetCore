using StrategyDesignPattern.Models;

namespace StrategyDesignPattern.Services.ShippingStrategies
{
    public class OvernightShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(Order order)
        {
            // Example: Higher flat rate, no per-item cost
            var baseCost = 25.00m;
            return baseCost;
        }
    }
}
