using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Sessions
{
  
    public class Authorize : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            SessionUser objUserSession = SessionExtension.Get<SessionUser>(context.HttpContext.Session, "SessionUser");
            if (objUserSession == null || (objUserSession != null && objUserSession.Id == 0))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"action","Login" },
                        {"contoller","Account" }
                    }
                    );
            }
            base.OnActionExecuting(context);
        }
    }
}
