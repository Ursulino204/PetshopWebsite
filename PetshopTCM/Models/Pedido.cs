using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetshopTCM.Models
{
    public class Pedido
    {
        public int cod_pedido { get; set; }
        public string descr_pedido { get; set; }
        public DateTime data_pedido { get; set; }
        public int cod_cli { get; set; }
        public int cod_especie { get; set; }
        public int cod_func { get; set; }
        public int cod_id_pag { get; set; }
        public int cod_pet { get; set; }
        public int cod_raca { get; set; }
    }
}