using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_dotnet.Domain.Enterprise.Entities;

public class TaskProps
{
    public string Title { get; set; }
    public bool Checked { get; set; }
    public string ListId { get; set; }
}


public class Task
{
    [Key]
    public string Id { get; set; }

    [MaxLength(255)]
    public string Title { get; set; }

    public bool Checked { get; set; }

    [ForeignKey("Lists")]
    public string ListId { get; set; }
    public List List { get; set; }

    public DateTime CreatedAt { get; set; }

    public Task(TaskProps props, string id)
    {
        Id = id ?? Guid.NewGuid().ToString();
        Title = props.Title;
        Checked = props.Checked;
        CreatedAt = DateTime.Now;
    }

    public static Task Create(TaskProps props, string id = null)
    {
        return new Task(props, id);
    }
}
