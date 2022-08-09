using Microsoft.AspNetCore.Mvc;

namespace APIs.NET;


[ApiController]
[Route("api/[controller]")]
public class HelloWordController : ControllerBase
{

    private readonly ILogger<HelloWordController> _logger;
    IHelloWordService helloWordService;
    TasksContext dbContext;

    public HelloWordController(ILogger<HelloWordController> logger, IHelloWordService helloword, TasksContext db)
    {
        _logger = logger;
        helloWordService = helloword;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("retornando algo");
        return Ok(helloWordService.GetHelloWord());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();

        return Ok();
    }
}
