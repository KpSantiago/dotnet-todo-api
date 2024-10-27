namespace api_dotnet.Domain.Application.UseCases.Errors;

public class RegisterNotFoundException : Exception
{
    public RegisterNotFoundException(string message) : base(message: message) { }
}
