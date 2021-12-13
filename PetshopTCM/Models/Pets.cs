using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Pets
    {

        public int cod_pet { get; set; }

        public int cod_especie { get; set; }

        public string nome_pet { get; set; }

        public Decimal idade_pet { get; set; }

        public string sexo_pet { get; set; }

    }
}