
namespace ACoreX.Extensions.Base.Core
{

    public static class ApiResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseAPIResponseWrapperMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiResponseMiddleware>();
        }
    }

}
