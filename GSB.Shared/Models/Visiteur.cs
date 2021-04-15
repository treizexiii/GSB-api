using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GSB.Shared.Models
{
    public class Visiteur
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        [Range(5,5,ErrorMessage="Le champ doit comporter 5 chiffres")]
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEmbauche { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSortie { get; set; }
        public List<LigneFrais> LignesFrais { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}