using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service;

namespace Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TokenValidationFilterAttribute: ActionFilterAttribute
    {
        //public ITokenService tokenService { get; set; }
        private readonly ITokenService tokenService;

        public TokenValidationFilterAttribute(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Your token validation logic goes here
            if (tokenService != null && !tokenService.IsTokenValid(context.HttpContext.Request.Cookies["token"]))
            {
                // If token is not valid, redirect to login page
                context.Result = new RedirectResult("/");
            }

            base.OnActionExecuting(context);
        }
    }
}
