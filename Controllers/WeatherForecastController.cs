using Microsoft.AspNetCore.Mvc;

namespace APIs.NET;

[ApiController]
//agregamos una ruta para todas las peticiones
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    //creamos una coleccion estatica para almacenar datos en memoria
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        //validamos si ListWeatherForecast tiene algun registro
        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            //generamos una lista
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //agregamos una ruta en espesifico a esta peticion
    [Route("Get/weatherforecast")]
    [Route("Get/weatherforecast2")]
    //creamos una ruta dinamica (agarra el nombre de la peticion (Get))
    [Route("action")]
    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {   
        //agregamos a lista lo que pasemos
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ///removemos de la lista
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }
}
