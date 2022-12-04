using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_technique.Models
{
    public class Candidature
    {
        [Key]
        public Guid CondidatureID { get; set; }
        
        [Required(ErrorMessage = "Le champ nom est obligatoire !")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ prénom est obligatoire !")]
        [Display(Name ="Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ email est obligatoire !")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ téléphone est obligatoire !")]
        [Phone]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ niveau d'étude est obligatoire !")]
        [Display(Name = "Niveau d'étude")]
        public string NiveauEtude { get; set; }

        [Required(ErrorMessage = "Le champ nombre d'années d'expérience est obligatoire !")]
        [Display(Name = "Années d'expérience")]
        [Range(0,50)]
        public string NbrAnneesExperience { get; set; }

        [Required(ErrorMessage = "Le champ dernier employeur est obligatoire !")]
        [Display(Name = "Dernier employeur")]
        public string DernierEmployeur { get; set; }

        //[Required(ErrorMessage = "Le CV est obligatoire !")]
        public string CVURL { get; set; }
        
        [NotMapped]
        //[Required(ErrorMessage = "Le CV est obligatoire !")]
        public IFormFile File { get; set; }
    }
}