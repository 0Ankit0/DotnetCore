using StrategyDesignPattern.Models;

namespace StrategyDesignPattern.Services.ShippingStrategies
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(Order order);
    }
}
