using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrySimpleApi.Helpers
{
    public interface IResponseBuilder
    {
        object SuccessResponse(string message, object[] data);
        object ErrorResponse(string message, string[] errors);
    }
}
