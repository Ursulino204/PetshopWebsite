using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Usuario
    {
        public int cod_usuario { get; set; }
        public string cpf_usuario { get; set; }

        public string nome_usuario { get; set; }

        public string email_usuario { get; set; }

        public string senha_usuario { get; set; }

        public string endereco_usuario { get; set; }

        public string estado_usuario { get; set; }

        public char cep_usuario { get; set; }

        public string cidade_usuario { get; set; }
    }
}