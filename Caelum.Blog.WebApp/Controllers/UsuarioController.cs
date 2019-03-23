using Microsoft.AspNetCore.Mvc;
using Caelum.Blog.WebApp.Models;
using Caelum.Blog.WebApp.Dados;
using Microsoft.AspNetCore.Http;
using Caelum.Blog.Negocio;
using Newtonsoft.Json;

namespace Caelum.Blog.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO _dao;

        public UsuarioController(UsuarioDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //ViewModel //Identity
        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _dao.Busca(model.Login, model.Password);
                if (usuario != null)
                {
                    var usuarioLogado = new Usuario
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        Login = usuario.Login,
                    };
                    //converter Usuario para uma string JSON
                    var usuarioJson = JsonConvert.SerializeObject(usuarioLogado);
                    HttpContext.Session.SetString("usuario", usuarioJson);
                    return RedirectToAction("Index", new
                    {
                        area = "admin",
                        controller = "post"
                    });
                }
                ModelState.AddModelError("usuarioNaoEncontrado", "Usuário não encontrado!");
            }
            return View("Login", model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Login");
        }
    }
}