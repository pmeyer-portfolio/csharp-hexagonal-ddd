using Microsoft.AspNetCore.Mvc;

namespace Neusta.Workshop.Buchungssystem.RestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}