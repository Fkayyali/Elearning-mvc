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
            if (tokenService != null && !tokenService.IsTokenValid(context.HttpContext.Request.Cookies["token"]))
            {
                context.Result = new RedirectResult("/");
            }

            base.OnActionExecuting(context);
        }
    }
}
