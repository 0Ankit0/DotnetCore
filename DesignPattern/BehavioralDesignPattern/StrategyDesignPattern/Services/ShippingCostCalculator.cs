using StrategyDesignPattern.Models;
using StrategyDesignPattern.Services.ShippingStrategies;

namespace StrategyDesignPattern.Services
{
    public class ShippingCostCalculator
    {
        private readonly IShippingStrategy _shippingStrategy;

        // The strategy is typically injected or passed in via constructor.
        public ShippingCostCalculator(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }

        public decimal Calculate(Order order)
        {
            // Delegate to the selected strategy
            return _shippingStrategy.CalculateShippingCost(order);
        }
    }
}
