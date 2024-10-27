using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Storage;

namespace api_dotnet.Domain.Enterprise.Entities;

public class List
{
    [Key]
    public string Id { get; set; }

    [MaxLength(255)]
    public string Title { get; set; }

    public ICollection<Task> Tasks { get; set; }

    public DateTime CreatedAt { get; set; }

    public List(string id = null)
    {
        Id = id ?? Guid.NewGuid().ToString();
        CreatedAt = DateTime.Now;
    }
}

