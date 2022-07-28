using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//en minimal api todos los controladores se generan aqui

app.MapGet("/", () => "Hello World!");

app.Run();
