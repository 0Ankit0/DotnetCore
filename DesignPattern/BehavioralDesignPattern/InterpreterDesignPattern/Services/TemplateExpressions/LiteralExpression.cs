namespace InterpreterDesignPattern.Services.Template
{
    public class LiteralExpression : IExpression
    {
        private readonly string _literalText;

        public LiteralExpression(string text)
        {
            _literalText = text;
        }

        public string Interpret(object model)
        {
            // Return the literal string as-is
            return _literalText;
        }
    }

}
