//creando el primer middleware
namespace APIs.NET
{
    public class TimeMiddleware
    {
        //permite invocar el proximo middleware que sigue en la logica
        readonly RequestDelegate next;

        public TimeMiddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async System.Threading.Tasks.Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            //invoca el middleware que sigue
            await next(context);

            //verificamos en el context, dentro del request en el query, existe  una key igual a time
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                //devolvemos la hora actual sobre el request (encima del parametro que venga)
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }
    }
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}