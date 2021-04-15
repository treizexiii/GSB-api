using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSB.Shared.Models
{
    public class Forfait
    {
        [Required]
        [Key]
        public string Id { get; set; }
        public string Libelle { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Montant { get; set; }
    }
}