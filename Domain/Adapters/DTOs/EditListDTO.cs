using System.ComponentModel.DataAnnotations;

namespace api_dotnet.Domain.Adapters.DTOs;

public class EditListDTO
{
    [MinLength(4, ErrorMessage = "O título deve ter no mínimo 4 caracteres")]
    public string Title { get; set; }
}
