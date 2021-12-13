using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Servico
    {
        public int cod_servico { get; set; }
        public int cod_func { get; set; }
        public int cod_pet { get; set; }
        public string desc_servico { get; set; }
        public Decimal valor_servico { get; set; }
        public string status_servico { get; set; }

    }
}