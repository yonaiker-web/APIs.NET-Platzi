using Microsoft.AspNetCore.Mvc;

namespace APIs.NET;

//agregamos la ruta para las peticiones al api
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    //recibimos el servicio de category (obtenemos la interface que es la que tiene la abstraccion de los servicios)
    ICategoryService categoryService;

    public CategoryController(ICategoryService service)
    {
        categoryService = service;
    }

    //creando endpoint


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }

    [HttpPost]
    //desde el cuerpo del body FromBody, le pasamos la categoria
    public IActionResult Post([FromBody] Category category)
    {
        categoryService.Save(category);
        return Ok();
    }

    [HttpPut("{id}")]
    //desde el cuerpo del body FromBody, le pasamos la categoria y el id
    public IActionResult Put(Guid id, [FromBody] Category category)
    {
        categoryService.Update(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.Delete(id);
        return Ok();
    }
}