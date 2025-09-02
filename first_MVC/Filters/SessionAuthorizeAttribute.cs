using Microsoft.AspNetCore.Mvc.Filters;

namespace first_MVC.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isLoggedIn = !string.IsNullOrEmpty(context.HttpContext.Session.GetString("User"));
            if (!isLoggedIn)
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
