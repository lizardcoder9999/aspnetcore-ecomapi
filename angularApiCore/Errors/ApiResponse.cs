using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularApiCore.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                203 => "Email Already in use",
                400 => "A bad request was made",
                401 => "Unauthorized Request",
                404 => "A Resource on the server was not found",
                500 => "Error on the server",
                _ => null,
            };
        }
    }
}
