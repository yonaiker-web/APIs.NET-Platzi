using Microsoft.AspNetCore.Mvc;

namespace APIs.NET;


[ApiController]
[Route("api/[controller]")]
public class HelloWordController : ControllerBase
{
    IHelloWordService helloWordService;

    public HelloWordController(IHelloWordService helloword)
    {
        helloWordService = helloword;
    }

    public IActionResult Get()
    {
        return Ok(helloWordService.GetHelloWord());
    }
}
