


namespace ACoreX.Authentication.Core
{

    public class AuthenticationAttribute : TypeFilterAttribute
    {
        public AuthenticationAttribute() : base(typeof(AuthenticationActionFilter))
        {

        }
    }

    public class AuthenticationActionFilter : IAuthorizationFilter
    {
        private IContainerBuilder _builder;
        public AuthenticationActionFilter(IContainerBuilder builder)
        {
            _builder = builder;
        }


        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            Microsoft.AspNetCore.Http.IHeaderDictionary headers = context.HttpContext.Request.Headers;
            Microsoft.AspNetCore.Http.HttpRequest request = context.HttpContext.Request;
            string tokenStr = headers["Authorization"].ToString().Replace("Bearer ", "");

            IAuthHandler authHandler = _builder.Create<IAuthHandler>();

            AuthenticateResult authResult = await context.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);

            IToken token = _builder.Create<IToken>();
            token.Value = tokenStr;
            if (authResult.Succeeded && authResult.Principal.Identity.IsAuthenticated && authHandler.Check(token))
            {

            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
