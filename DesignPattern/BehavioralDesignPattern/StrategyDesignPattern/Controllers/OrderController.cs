using Microsoft.AspNetCore.Mvc;
using StrategyDesignPattern.Models;
using StrategyDesignPattern.Services.ShippingStrategies;
using StrategyDesignPattern.Services;

namespace StrategyDesignPattern.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShippingStrategyFactory _strategyFactory;

        public OrdersController(ShippingStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }
        // Example: GET: /Orders/Checkout
        [HttpGet]
        public IActionResult Checkout()
        {
            // Typically you'd retrieve an order from the database or session
            var sampleOrder = new Order
            {
                Id = 101,
                ItemCount = 3,
                TotalAmount = 59.99m
            };

            // Just show a simple checkout page
            return View(sampleOrder);
        }

        // Example: POST: /Orders/Checkout
        [HttpPost]
        public IActionResult Checkout(Order order, string shippingOption)
        {
            var strategy = _strategyFactory.GetStrategy(shippingOption);
            var calculator = new ShippingCostCalculator(strategy);
            var shippingCost = calculator.Calculate(order);

            ViewBag.ShippingOption = shippingOption;
            ViewBag.ShippingCost = shippingCost;

            // 3. Show the results (in a real app, you'd proceed to payment, etc.)
            return View("Confirmation", order);
        }
    }
}
