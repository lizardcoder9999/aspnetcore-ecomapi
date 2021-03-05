using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularApiCore.Errors;
using Microsoft.AspNetCore.Mvc;

namespace angularApiCore.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        protected IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
