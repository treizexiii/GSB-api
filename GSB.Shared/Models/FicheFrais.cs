using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GSB.Shared.Models
{
    public class FicheFrais
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Mois { get; set; }
        public LigneFrais LignesFrais { get; set; }

        public string EtatId { get; set; }
        public Etat Etat { get; set; }

        public int VisiteurId { get; set; }
        [JsonIgnore]
        public Visiteur Visiteur { get; set; }

        public string ForfaitId { get; set; }
        public Forfait Forfait { get; set; }

        public int Justificatifs { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantValide { get; set; }

        public DateTime DateModification { get; set; }
    }
}