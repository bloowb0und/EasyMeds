using System.Net;
using EasyMeds.WebAPI.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyMeds.WebAPI.Core.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class DoctorRoleInterceptorAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.HasDoctorRole())
        {
            context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            return;
        }

        base.OnActionExecuting(context);
    }
}