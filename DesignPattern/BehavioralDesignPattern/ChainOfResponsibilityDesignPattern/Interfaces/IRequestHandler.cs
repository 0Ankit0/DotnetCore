namespace ChainOfResponsibilityDesignPattern.Interfaces
{
    public interface IRequestHandler
    {
        IRequestHandler SetNext(IRequestHandler next);
        Task HandleAsync(HttpContext context);
    }

}
