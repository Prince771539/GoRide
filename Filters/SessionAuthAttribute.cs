using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using GoRide.Models.Enums;

namespace GoRide.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class SessionAuthAttribute : ActionFilterAttribute
    {
        public UserRole[] Roles { get; set; }

        public SessionAuthAttribute(params UserRole[] roles)
        {
            Roles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var userId = session.GetInt32("UserId");
            var roleStr = session.GetString("UserRole");

            if (userId == null || string.IsNullOrEmpty(roleStr))
            {
                // Not logged in
                context.Result = new RedirectToActionResult("UserLogin", "Account", null);
                return;
            }

            if (Roles != null && Roles.Length > 0)
            {
                if (Enum.TryParse(typeof(UserRole), roleStr, out var parsedRole))
                {
                    var userRole = (UserRole)parsedRole;
                    // Check if user has required role
                    bool hasRole = false;
                    foreach (var role in Roles)
                    {
                        if (userRole == role)
                        {
                            hasRole = true;
                            break;
                        }
                    }

                    if (!hasRole)
                    {
                        // Unauthorized
                        context.Result = new RedirectToActionResult("UserLogin", "Account", null);
                        return;
                    }
                }
                else
                {
                    context.Result = new RedirectToActionResult("UserLogin", "Account", null);
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
