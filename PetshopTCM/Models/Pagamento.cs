using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Pagamento
    {
        public int cod_id_pag { get; set; }
        public int cod_pedido { get; set; }

        [Display(Name = "Metodo de Pagamento")]
        public string metodo_pag { get; set; }

        [Display(Name = "Valor do Pagamento")]

        public float valor_total { get; set; }
    }
}