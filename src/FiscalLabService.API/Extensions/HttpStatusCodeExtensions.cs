using System.Net;

namespace FiscalLabService.API.Extensions;

public static class HttpStatusCodeExtensions
{
    public static int GetErrorStatusCode(this string errorCode)
    {
        if (errorCode.Contains("not_found"))
        {
            return (int)HttpStatusCode.NotFound;
        }
        
        return errorCode.Contains("duplicated") ? (int)HttpStatusCode.Conflict : (int)HttpStatusCode.BadRequest;
    }
}