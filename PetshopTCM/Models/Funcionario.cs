using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Funcionario
    {
        public int cod_func { get; set; }
        [Display(Name = "Nome do Funcionario")]

        public string nome_func { get; set; }

    }
}