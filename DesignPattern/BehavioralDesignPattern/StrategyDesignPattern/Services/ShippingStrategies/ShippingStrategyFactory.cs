namespace StrategyDesignPattern.Services.ShippingStrategies
{
    public class ShippingStrategyFactory
    {
        private readonly IEnumerable<IShippingStrategy> _strategies;

        public ShippingStrategyFactory(IEnumerable<IShippingStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IShippingStrategy GetStrategy(string name)
        {
            return _strategies.FirstOrDefault(s => s.GetType().Name.StartsWith(name))
                   ?? new StandardShippingStrategy();
        }
    }

}
