using Microsoft.EntityFrameworkCore;

namespace APIs.NET;

public class TasksContext : DbContext
{
    //agregamos las colecciones que representan las tablas en la base de datos
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    //reescribimos en modelo de la base de datos con sus restricciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //creamos datos semillas a categoria
        List<Category> categoriasInit = new List<Category>();
        categoriasInit.Add(new Category() { CategoryId = Guid.Parse("e62a447f-de7d-4070-b4e9-435e2b0ce623"), Name = "Actividades Pendientes", Peso = 20 });
        categoriasInit.Add(new Category() { CategoryId = Guid.Parse("e62a447f-de7d-4070-b4e9-435e2b0ce6AF"), Name = "Actividades Personales", Peso = 50 });


        modelBuilder.Entity<Category>(c =>
        {
            c.ToTable("Categoria");
            c.HasKey(c => c.CategoryId);
            c.Property(c => c.Name).IsRequired().HasMaxLength(150);
            c.Property(c => c.Description).IsRequired(false);
            c.Property(c => c.Peso);
            //HasData permite agregar datos iniciales (datos semilla)
            c.HasData(categoriasInit);
        });

        //creamos datos semillas a tareas
        List<Task> tareasInit = new List<Task>();
        tareasInit.Add(new Task() { TaskId = Guid.Parse("e62a447f-de7d-4070-b4e9-435e2b0ce610"), CategoryId = Guid.Parse("e62a447f-de7d-4070-b4e9-435e2b0ce623"), PriorityTask = Priority.Media, Title = "Pago de servicios publicos", Creation = DateTime.Now });
        tareasInit.Add(new Task() { TaskId = Guid.Parse("e62a447f-de7d-4070-b4e9-435e2b0ce611"), CategoryId = Guid.Parse("e62a447f-de7d-4070-b4e9-435e2b0ce6AF"), PriorityTask = Priority.Baja, Title = "Terminar de ver Pelicula en Netflix", Creation = DateTime.Now });

        modelBuilder.Entity<Task>(t =>
        {
            t.ToTable("Tarea");
            t.HasKey(t => t.TaskId);
            //HasOne, para configurar la llave foranea
            t.HasOne(t => t.Category).WithMany(t => t.Task).HasForeignKey(t => t.CategoryId);
            t.Property(t => t.Title).IsRequired().HasMaxLength(200);
            t.Property(t => t.Description).IsRequired(false);
            t.Property(t => t.PriorityTask);
            t.Property(t => t.Creation);
            t.Ignore(t => t.Resumen);
            t.HasData(tareasInit);
        });
    }
}
