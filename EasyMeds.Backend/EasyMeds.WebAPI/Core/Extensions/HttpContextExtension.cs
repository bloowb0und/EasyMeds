using EasyMeds.WebAPI.Core.Constants;
using EasyMeds.WebAPI.Core.Entities;

namespace EasyMeds.WebAPI.Core.Extensions;

public static class HttpContextExtension
{
    public static bool HasDoctorRole(this HttpContext httpContext)
    {
        var isDoctor = httpContext.Items["IsDoctor"] as bool? ?? false;
        return isDoctor;
    }
}