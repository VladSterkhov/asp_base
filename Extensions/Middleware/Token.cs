using Middlewares;

namespace Extensions;

public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
    {
        return builder.UseMiddleware<TokenMidleware>(pattern);
    }
}