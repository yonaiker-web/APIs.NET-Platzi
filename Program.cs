using System.Collections.ObjectModel;
using APIs.NET;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//realizar las inyeccion de dependencias antes del Build()
//este crear una nueva instancia de la dependncia que usamos pero a nivel de controlador o a nivel de clases
// builder.Services.AddScoped();
//se va a crear una unica implementacion o instancia y se crea a nivel de toda a API (lo crea en memoria)
// builder.Services.AddSingleton()

//en esta forma de hacer inyeccion de dependencia si cambiamos la interface o la clase, se cambia en todos los controladores que la usen
// builder.Services.AddScoped<IHelloWordService, HelloWordService>();
builder.Services.AddScoped<IHelloWordService>(p => new HelloWordService());

//implementamos la inyeccion de dependencias para los sevicios de Category y Task
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//pagina de bienvenido que se muestra cada vez que un usuario ingresa a la pagina
// app.UseWelcomePage();

//hacemos el llamado al middleware que creamos
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
