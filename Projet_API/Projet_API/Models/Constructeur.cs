using System.ComponentModel.DataAnnotations;

namespace Projet_API.Models
{
    public class Constructeur
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

    }
}
