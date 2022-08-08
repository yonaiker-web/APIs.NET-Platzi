namespace APIs.NET;

public class TaskService : ITaskService
{
    TasksContext context;

    public TaskService(TasksContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Task> Get()
    {
        return context.Tasks;
    }

    //metodo para guardar
    public async System.Threading.Tasks.Task Save(Task task)
    {
        context.Add(task);
        await context.SaveChangesAsync();
    }

    //metodo para actualizar
    public async System.Threading.Tasks.Task Update(Guid id, Task task)
    {
        //buscamos el elemento por id
        var taskCurrent = context.Tasks.Find(id);

        //si encontramos el objeto
        if (taskCurrent != null)
        {
            //actualizamos los datos
            taskCurrent.Title = task.Title;
            taskCurrent.Description = task.Description;
            taskCurrent.PriorityTask = task.PriorityTask;

            await context.SaveChangesAsync();
        }
    }

    //metodo para eliminar 
    public async System.Threading.Tasks.Task Delete(Guid id)
    {
        //buscamos el elemento por id
        var taskCurrent = context.Tasks.Find(id);

        //si encontramos el objeto
        if (taskCurrent != null)
        {
            //eliminamos del contexto
            context.Remove(taskCurrent);

            await context.SaveChangesAsync();
        }
    }

}


public interface ITaskService
{
    IEnumerable<Task> Get();
    System.Threading.Tasks.Task Save(Task task);
    System.Threading.Tasks.Task Update(Guid id, Task task);
    System.Threading.Tasks.Task Delete(Guid id);

}