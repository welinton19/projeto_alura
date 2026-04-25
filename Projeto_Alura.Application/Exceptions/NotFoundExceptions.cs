namespace Projeto_Alura.Application.Exceptions;

public class NotFoundExceptions : Exception
{
    public NotFoundExceptions(string message) : base(message) { }

    public NotFoundExceptions(string name, object key) : base($"{name} com Id '{key}' não foi encontrado!") { }
}
