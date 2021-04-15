using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GSB.Shared.Models
{
    public class LigneFrais
    {
        [Key]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Mois { get; set; }

        public List<FicheFrais> FicheFrais { get; set; }

        public int VisiteurId { get; set; }
        [JsonIgnore]
        public Visiteur Visiteur { get; set; }

    }
}