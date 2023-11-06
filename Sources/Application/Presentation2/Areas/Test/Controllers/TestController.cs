using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mmu.CleanBlazor.Presentation2.Areas.Test.Controllers
{
    [PublicAPI]
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController
    {
        public const string ExceptionMessage = "ExceptionMessage";
        
        [HttpGet("exception")]
        public IActionResult ThrowException()
        {
            throw new Exception(ExceptionMessage);
        }
    }
}
