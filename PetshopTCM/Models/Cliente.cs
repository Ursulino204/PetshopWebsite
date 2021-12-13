using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Cliente
    {
        public int cod_cli { get; set; }

        [Display(Name = "Nome do Cliente")]

        public string nome_cli { get; set; }

        [Display(Name = "Endereco do Cliente")]
        public string endereco_cli { get; set; }

        [Display(Name = "Cidade do Cliente")]

        public string cidade_cli { get; set; }

        [Display(Name = "Telefone do Cliente")]

        public int telefone_cli { get; set; }
        [Display(Name = "Email do Cliente")]

        public string email_cli { get; set; }
        [Display(Name = "Cep do Cliente")]

        public int cep_cli { get; set; }

    }
}