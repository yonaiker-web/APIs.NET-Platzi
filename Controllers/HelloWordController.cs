using Microsoft.AspNetCore.Mvc;

namespace APIs.NET;


[ApiController]
[Route("api/[controller]")]
public class HelloWordController : ControllerBase
{

    private readonly ILogger<HelloWordController> _logger;
    IHelloWordService helloWordService;

    public HelloWordController(ILogger<HelloWordController> logger, IHelloWordService helloword)
    {
        _logger = logger;
        helloWordService = helloword;
    }

    public IActionResult Get()
    {
        _logger.LogInformation("retornando algo");
        return Ok(helloWordService.GetHelloWord());
    }
}
