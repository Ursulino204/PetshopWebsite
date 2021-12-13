using PetshopTCM.Models;
using PetshopTCM.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PetshopTCM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Acoes Ac = new Acoes();

        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult VerificarUsuario(Usuario u)
        {
            Ac.TestarUsuario(u);

            if (u.nome_usuario != null && u.senha_usuario != null)
            {
                FormsAuthentication.SetAuthCookie(u.nome_usuario, false);
                Session["usuarioLogado"] = u.nome_usuario.ToString();
                Session["senhaLogado"] = u.senha_usuario.ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }


        }
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Login", "Login");
        }

    }
}