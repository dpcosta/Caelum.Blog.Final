using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caelum.Blog.Negocio;
using Caelum.Blog.WebApp.Dados;

namespace Caelum.Blog.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private PostDAOComEF _dao;

        public HomeController(PostDAOComEF dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            var lista = _dao.Listar().Where(p => p.Publicado);
            return View(lista);
        }

        public IActionResult Busca(string termo)
        {
            var lista = _dao.Listar()
                .Where(p => p.Publicado && p.Titulo.Contains(termo));
            return View("Index", lista);
        }
    }
}
