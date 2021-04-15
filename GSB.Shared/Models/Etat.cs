using System.ComponentModel.DataAnnotations;

namespace GSB.Shared.Models
{
    public class Etat
    {
        [Required]
        [Key]
        public string Id { get; set; }
        public string Libelle { get; set; }
    }
}