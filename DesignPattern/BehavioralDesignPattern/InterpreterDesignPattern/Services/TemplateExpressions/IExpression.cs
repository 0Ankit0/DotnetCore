namespace InterpreterDesignPattern.Services.Template
{
    public interface IExpression
    {
        string Interpret(object model);
    }
}
