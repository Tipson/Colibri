using Colibri.Infrastructure.Services;

namespace Colibri.Middleware;

public class EnsureUserExistsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UserService _userService;

    public EnsureUserExistsMiddleware(RequestDelegate next, UserService userService)
    {
        _next = next;
        _userService = userService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Запускайте метод Execute только при первом запросе
        if (context.Request.Path == "/")
        {
            await _userService.Execute();
        }

        // вызов следующего middleware в конвейере
        await _next(context);
    }
}