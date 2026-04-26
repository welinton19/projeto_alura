using Projeto_Alura.Application.Exceptions;

namespace Projeto_Alura.Middlewres;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next; 

    
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundExceptions ex)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new
            {
                error = ex.Message
            });
        }
       
        catch (Exception)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Erro interno no servidor!"
            });
        }
    }
}