using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Especie
    {
         public int cod_especie { get; set; }

        [Display(Name = "Nome da Especie")]

        public string nome_especie { get; set; }

        public int cod_pet { get; set; }
    }
}