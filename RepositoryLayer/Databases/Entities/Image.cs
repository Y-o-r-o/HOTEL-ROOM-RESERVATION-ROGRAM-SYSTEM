using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Databases.Entities;

public class Image
{
    [Key]
    public int Id { get; set; }
    public string Path { get; set; }
}