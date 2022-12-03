using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_technique.Models
{
    public class Candidature
    {
        [Key]
        public Guid CondidatureID { get; set; }
        
        [Required]
        public string Nom { get; set; }

        [Required]
        [Display(Name ="Prénom")]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Niveau d'étude")]
        public string NiveauEtude { get; set; }

        [Display(Name = "Nombre d'années d'expérience")]
        public string NbrAnneesExperience { get; set; }
        
        [Display(Name = "Dernier employeur")]
        public string DernierEmployeur { get; set; }
        public string CVURL { get; set; }
    }
}