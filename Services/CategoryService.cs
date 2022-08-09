namespace APIs.NET;

public class CategoryService : ICategoryService
{
    TasksContext context;

    public CategoryService(TasksContext dbcontext)
    {
        context = dbcontext;
    }

    //para devolver una lista de las categorias
    public IEnumerable<Category> Get()
    {
        return context.Category;
    }

    //metodo para guardar
    public async System.Threading.Tasks.Task Save(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }

    //metodo para actualizar
    public async System.Threading.Tasks.Task Update(Guid id, Category category)
    {
        //buscamos el elemento por id
        var categoryCurrent = context.Category.Find(id);

        //si encontramos el objeto
        if (categoryCurrent != null)
        {
            //actualizamos los datos
            categoryCurrent.Name = category.Name;
            categoryCurrent.Description = category.Description;
            categoryCurrent.Peso = category.Peso;

            await context.SaveChangesAsync();
        }
    }

    //metodo para eliminar 
    public async System.Threading.Tasks.Task Delete(Guid id)
    {
        //buscamos el elemento por id
        var categoryCurrent = context.Category.Find(id);

        //si encontramos el objeto
        if (categoryCurrent != null)
        {
            //eliminamos del contexto
            context.Remove(categoryCurrent);

            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    System.Threading.Tasks.Task Save(Category category);
    System.Threading.Tasks.Task Update(Guid id, Category category);
    System.Threading.Tasks.Task Delete(Guid id);

}