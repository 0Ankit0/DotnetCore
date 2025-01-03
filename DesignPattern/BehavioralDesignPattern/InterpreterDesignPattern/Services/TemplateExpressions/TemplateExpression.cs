namespace InterpreterDesignPattern.Services.Template
{
    public class TemplateExpression : IExpression
    {
        private readonly List<IExpression> _expressions = new List<IExpression>();

        public void AddExpression(IExpression expression)
        {
            _expressions.Add(expression);
        }

        public string Interpret(object model)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var expr in _expressions)
            {
                sb.Append(expr.Interpret(model));
            }
            return sb.ToString();
        }
    }

}
