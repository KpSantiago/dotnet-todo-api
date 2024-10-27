using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api_dotnet.Domain.Enterprise.Entities;

public class Task
{
    [Key]
    public string Id { get; set; }

    [MaxLength(255)]
    public string Title { get; set; }

    public bool Checked { get; set; }

    [ForeignKey("Lists")]
    public string ListId { get; set; }

    [JsonIgnore]
    public List List { get; set; }

    public DateTime CreatedAt { get; set; }

    public Task(string id = null)
    {
        Id = id ?? Guid.NewGuid().ToString();
        CreatedAt = DateTime.Now;
    }
}
