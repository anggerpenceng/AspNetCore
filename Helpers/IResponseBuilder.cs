using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TrySimpleApi.Helpers
{
    public interface IResponseBuilder
    {
        object SuccessResponse(string message, dynamic data);
        object ErrorResponse(string message, string[] errors);
    }
}
