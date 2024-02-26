using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Service;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate next;
    private ITokenService? tokenService;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITokenService tokenService)
    {
        this.tokenService = tokenService;
        if (this.tokenService != null && !(this.tokenService.IsTokenValid(context.Request.Cookies["token"])))
        {
            context.Response.Redirect("/");
            return;
        }

        await next(context);
    }
}