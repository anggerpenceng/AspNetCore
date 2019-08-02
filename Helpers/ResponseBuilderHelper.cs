using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TrySimpleApi.Helpers
{
    public class ResponseBuilderHelper : IResponseBuilder
    {

        public object SuccessResponse(string message, object[] data)
        {
            return new
            {
                success = true,
                message,
                data
            };
        }

        public object ErrorResponse(string message, string[] errors)
        {
            return new
            {
                success = false,
                message,
                errors
            };
        }

    }
}
