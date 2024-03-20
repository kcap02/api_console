using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_API.Models
{
    
    
        public class ChiffresVentes
        {
            [Key]
            public int Id { get; set; }



            [Required]
            public required string Annee { get; set; }
            [Required]
            public int NombreVentes { get; set; }
            [ForeignKey("Console")]

            public  required int id_console { get; set; }





        }
    
}
