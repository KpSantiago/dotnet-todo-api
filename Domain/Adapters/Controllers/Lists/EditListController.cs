using api_dotnet.Domain.Adapters.DTOs;
using api_dotnet.Domain.Application.UseCases.Exceptions;
using api_dotnet.Domain.Application.UseCases.Factories;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Domain.Adapters.Controllers.Lists;

[ApiController]
[Route("lists/{id}/update")]
[ApiExplorerSettings(GroupName = "Lists")]
public class EditListController : ControllerBase
{
    private readonly TodoContext _context;

    public EditListController(TodoContext context)
    {
        _context = context;
    }

    [HttpPatch]
    public IActionResult Handle(EditListDTO data, string id)
    {
        try
        {
            var editListUseCase = new MakeEditListUseCase(_context).Factorie();
            var list = editListUseCase.Execute(data, id);

            return Ok(new { message = "Lista editada com sucesso.", list });
        }
        catch (RegisterNotFoundException ex)
        {
            return NotFound(new { message = ex.Message, statudCode = 404, error = "Not Found" });
        }
    }
}
