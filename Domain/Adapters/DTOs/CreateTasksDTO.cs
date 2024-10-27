using System.ComponentModel.DataAnnotations;

namespace api_dotnet.Domain.Adapters.DTOs;
public class CreateTasksDTO
{
    [MinLength(4, ErrorMessage = "O título deve ter no mínimo 4 caracteres.")]
    public string Title { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "O Id da lista é obirgatório")]
    public string ListId { get; set; }
}