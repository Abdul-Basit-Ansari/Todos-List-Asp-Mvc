using System.ComponentModel.DataAnnotations;

namespace TodosList.Models;

public class Todos
{
    public int id { get; set; }
    public string? Title { get; set; }
    public string? Desc { get; set; }
}
