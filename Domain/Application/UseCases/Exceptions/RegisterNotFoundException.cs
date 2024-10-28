namespace api_dotnet.Domain.Application.UseCases.Exceptions;

public class RegisterNotFoundException : Exception
{
    public RegisterNotFoundException(string message) : base(message: message) { }
}
