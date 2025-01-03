namespace InterpreterDesignPattern.Services.Template
{
    public class PlaceholderExpression : IExpression
    {
        private readonly string _propertyName;
        private readonly string _format;

        public PlaceholderExpression(string propertyName, string format = null)
        {
            _propertyName = propertyName;
            _format = format;
        }

        public string Interpret(object model)
        {
            if (model == null) return string.Empty;

            var propertyInfo = model.GetType().GetProperty(_propertyName);
            if (propertyInfo == null)
                return string.Empty;

            var value = propertyInfo.GetValue(model);
            if (value == null)
                return string.Empty;

            // If there's a format and the property type supports formatting
            if (!string.IsNullOrEmpty(_format))
            {
                // For example, if property is DateTime or numeric, we can do something like:
                if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    // Cast to DateTime, then ToString(format)
                    var dtValue = (DateTime)value;
                    return dtValue.ToString(_format);
                }
                else if (propertyInfo.PropertyType == typeof(decimal)
                      || propertyInfo.PropertyType == typeof(double)
                      || propertyInfo.PropertyType == typeof(float)
                      || propertyInfo.PropertyType == typeof(int))
                {
                    // Numeric types
                    return string.Format($"{{0:{_format}}}", value);
                }
                else
                {
                // If you want to handle other types with .ToString(_format), you can attempt that too:
                    return string.Format($"{{0:{_format}}}", value);
                }
            }

            // If no format is specified or not applicable, just do a normal .ToString()
            return value.ToString();
        }
    }

}
