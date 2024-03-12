using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_API.Models
{
    public class ConsoledeJeux
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Model { get; set; }
        [ForeignKey("Constructeur")]
        public required int idConstructeur { get; set; }
    }
}
