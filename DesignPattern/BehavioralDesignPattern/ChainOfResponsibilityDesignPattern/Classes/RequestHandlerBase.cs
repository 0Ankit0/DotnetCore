using ChainOfResponsibilityDesignPattern.Interfaces;

namespace ChainOfResponsibilityDesignPattern.Classes
{
    public abstract class RequestHandlerBase : IRequestHandler
    {
        private IRequestHandler _nextHandler;

        public IRequestHandler SetNext(IRequestHandler next)
        {
            _nextHandler = next;
            return next;
        }

        public virtual async Task HandleAsync(HttpContext context)
        {
            if (_nextHandler != null)
            {
                await _nextHandler.HandleAsync(context);
            }
        }
    }

}
