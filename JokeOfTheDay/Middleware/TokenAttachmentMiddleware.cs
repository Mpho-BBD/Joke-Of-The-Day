using JokeOfTheDay.Services;
using System.Globalization;

namespace JokeOfTheDay.Middleware;
public class TokenAttachmentMiddleware
{
    private readonly RequestDelegate _next;

    public TokenAttachmentMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;
        if (path != null && !path.Split("/").Contains("session"))
        {
            var cookie = new CookieService().GetSession(context.Request);
            string access = TokenCache.ValidateToken(cookie);
            context.Request.Headers["Authorization"] = "Bearer " + access ?? String.Empty;
        }else
        {
            try
            {
                var code = context.Request.Query["code"];
                string uuid = TokenCache.AddNewToken(code);

                if (uuid == null)
                    throw new InvalidDataException("Failed dependancy");



                try
                {
                    if (!(uuid.Length == 37))
                    {
                        throw new ArgumentException("Do not have permission");
                    }
                }
                catch (Exception) {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Do not have permission");
                    return;
                }
                

                var tok = TokenCache.ValidateToken(uuid);
                context.Request.Headers["Authorization"] = "Bearer " + tok;
                new CookieService().SetSessionCookie(context.Response, uuid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Failed to create new session");
                return;
            }
        }
        
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public static class TokenAttachmentMiddlewareExtensions
{
    public static IApplicationBuilder UseTokenAttachmentMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenAttachmentMiddleware>();
    }
}