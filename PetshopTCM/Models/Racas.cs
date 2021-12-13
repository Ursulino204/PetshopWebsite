using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Racas
    {
        public int cod_raca { get; set; }

        [Display(Name = "Nome da Raca")]

        public string nome_raca { get; set; }

        public int cod_especie { get; set; }
    }
}