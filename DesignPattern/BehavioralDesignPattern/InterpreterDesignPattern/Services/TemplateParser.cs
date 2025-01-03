
using InterpreterDesignPattern.Services.Template;
using System.Text.RegularExpressions;

namespace InterpreterDesignPattern.Services
{

    public static class TemplateParser
    {
        public static TemplateExpression Parse(string template)
        {
            var templateExpression = new TemplateExpression();

            var pattern = new Regex(@"(\{\{.*?\}\})");
            var segments = pattern.Split(template);

            foreach (var segment in segments)
            {
                if (string.IsNullOrEmpty(segment)) continue;

                if (segment.StartsWith("{{") && segment.EndsWith("}}"))
                {
                    // e.g., "{{OrderDate:yyyy-MM-dd}}"
                    var placeholder = segment.Trim('{', '}'); // e.g. "OrderDate:yyyy-MM-dd"

                    // If there's a colon, parse out the format
                    var parts = placeholder.Split(':', 2); // split on the first colon
                    var propertyName = parts[0];
                    string format = parts.Length > 1 ? parts[1] : null;

                    templateExpression.AddExpression(new PlaceholderExpression(propertyName, format));
                }
                else
                {
                    templateExpression.AddExpression(new LiteralExpression(segment));
                }
            }

            return templateExpression;
        }
    }
}
