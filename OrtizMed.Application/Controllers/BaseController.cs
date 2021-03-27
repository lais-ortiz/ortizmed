using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OrtizMed.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> GenerateResponseAsync<TDataObject>(Func<Task<TDataObject>> func)
        {
            try
            {
                var response = await func();

                return StatusCode((int)HttpStatusCode.OK, new
                {
                    data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    data = new { },
                    notifications = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
    }
}
