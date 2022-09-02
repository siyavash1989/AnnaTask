namespace API.Middlewares
{
    public interface IMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}