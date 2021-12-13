using PetshopTCM.Models;
using PetshopTCM.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetshopTCM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        Acoes Ac = new Acoes();

        public ActionResult Servico()
        {
            Servico serv = new Servico();
            return View(serv);
        }
        //CADASTRAR SERVICOS

        [HttpPost]
        public ActionResult CadastrarServico(Servico serv)
        {
            Ac.CadastrarServico(serv);
            return View(serv);
        }



        public ActionResult ConsultarServico()
        {
            var ExibirServico = new Acoes();
            var TodosServico = ExibirServico.ListarServico();
            return View(TodosServico);
        }
        [HttpGet]
        [Route("whatever/{cd}")]
         public ActionResult AlterarServico (int cd)
        {
            int yourNewVariable = cd;
            var CodServico = Ac.ListarServicoCod(cd);
            if (CodServico == null )
            {
                return HttpNotFound();
            }
            return View(CodServico);
        }
        [HttpPost]
        public ActionResult AlterarServico(Servico s)
        {
            Ac.AlterarServico(s);
            return RedirectToAction("ConsultarServico");
        }
      
        public ActionResult DelServico(int cd)
        {
            Ac.DeletarServico(cd);
            return View();
        }


        public ActionResult Pagamento(Pagamento p)
        {
            Ac.Pagamento(p);
            return View(p);
        }
        public ActionResult Pedido(Pedido ped)
        {
            Ac.Pedido(ped);
            return View(ped);
        }


    }
}