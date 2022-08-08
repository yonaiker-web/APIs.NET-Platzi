using Microsoft.AspNetCore.Mvc;

namespace APIs.NET;

//agregamos la ruta para las peticiones al api
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    //recibimos el servicio de task (obtenemos la interface que es la que tiene la abstraccion de los servicios)
    ITaskService taskService;

    public TaskController(ITaskService service)
    {
        taskService = service;
    }

    //creando endpoint

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(taskService.Get());
    }

    [HttpPost]
    //desde el cuerpo del body FromBody, le pasamos la tareas
    public IActionResult Post([FromBody] Task task)
    {
        taskService.Save(task);
        return Ok();
    }

    [HttpPut("{id}")]
    //desde el cuerpo del body FromBody, le pasamos la categoria y el id
    public IActionResult Put(Guid id, [FromBody] Task task)
    {
        taskService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        taskService.Delete(id);
        return Ok();
    }
}