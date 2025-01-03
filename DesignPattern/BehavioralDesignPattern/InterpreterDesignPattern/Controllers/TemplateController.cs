

using InterpreterDesignPattern.Models;
using InterpreterDesignPattern.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterpreterDesignPattern.Controllers
{
    public class TemplateController : Controller
    {
        private static string _savedTemplate = "";

        [HttpGet]
        public IActionResult CreateTemplate()
        {
            // If there's an existing template, let's display it
            ViewBag.SavedTemplate = _savedTemplate;

            // 1) Reflect over EmailModel's properties to generate placeholders
            var props = typeof(EmailModel).GetProperties();
            // e.g., for FirstName, create "{{FirstName}}"
            var placeholders = props.Select(p => $"{{{{{p.Name}}}}}").ToList();

            // 2) We can also suggest placeholders with formatting
            //     e.g., for date properties, we might show an example formatting: {{OrderDate:yyyy-MM-dd}}
            //     But let's keep it simple here by generating the base placeholder plus examples for DateTime:
            var advancedPlaceholders = new List<string>();
            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(DateTime))
                {
                    // Example: "{{OrderDate:yyyy-MM-dd}}"
                    advancedPlaceholders.Add($"{{{{{prop.Name}:yyyy-MM-dd}}}}");
                    advancedPlaceholders.Add($"{{{{{prop.Name}:MM/dd/yyyy}}}}");
                }
                // For decimal or double, we might show a currency format
                else if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(double))
                {
                    // Example: "{{OrderTotal:C}}"
                    advancedPlaceholders.Add($"{{{{{prop.Name}:C}}}}");
                }
            }

            // Combine them into one list or pass separately
            ViewBag.BasicPlaceholders = placeholders;        // e.g.  {{FirstName}}, {{OrderDate}}
            ViewBag.AdvancedPlaceholders = advancedPlaceholders; // e.g.  {{OrderDate:yyyy-MM-dd}}

            return View();
        }

        [HttpPost]
        public IActionResult CreateTemplate(string templateInput)
        {
            _savedTemplate = templateInput ?? "";
            return RedirectToAction("SendEmail");
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            var model = new EmailModel(); // blank for GET
            return View(model);
        }

        [HttpPost]
        public IActionResult SendEmail(EmailModel model)
        {
            // 1) Retrieve the saved template
            var template = _savedTemplate;

            // 2) Interpret the template with the model
            var expression = TemplateParser.Parse(template);
            var result = expression.Interpret(model);

            // 3) Show the substituted text
            ViewBag.InterpretedResult = result;
            return View(model);
        }
    }
}
