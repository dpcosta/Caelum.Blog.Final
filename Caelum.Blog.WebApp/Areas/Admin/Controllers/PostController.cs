using Microsoft.AspNetCore.Mvc;
using Caelum.Blog.Negocio;
using Caelum.Blog.WebApp.Dados;
using Caelum.Blog.WebApp.Filtros;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Caelum.Blog.WebApp.Controllers
{
    [Area("Admin")]
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private PostDAOComEF _dao;

        public PostController(PostDAOComEF dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            
            ViewBag.Posts = _dao.Listar();
            return View();
        }

        public IActionResult Novo()
        {
            var post = new Post();
            //return View("Novo", post); //formulário
            //msm q acima, mas posso abreviar qdo nome da action 
            //é igual ao nome da view
            return View(post);
        }

        [HttpPost] //atributo >> anotação
        public IActionResult Adiciona(Post post) //model binding
        {
            // titulo - título obrigatório, qtde de cars excede 50
            // resumo - obti
            // aidaoi - 
            // ModelState - válido ou inválido

            //titulo obrigatório
            //titulo com no máximo 50 caracteres
            //resumo obrigatório
            if (ModelState.IsValid)
            {
                var usuarioJson = HttpContext.Session.GetString("usuario");
                var usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
                post.Autor = usuario;
                _dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            return View("Novo", post);
        }

        // Post/Visualiza/132676
        public IActionResult Visualiza(int id)
        {
            var post = _dao.BuscarPorId(id); //cuidado, pode retornar null!
            if (post != null)
            {
                return View(post); //post será usado na propriedade Model
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Atualiza(Post post)
        {
            if (ModelState.IsValid)
            {
                _dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            return View("Visualiza", post);
        }

        // Post/Remove/13268136
        public IActionResult Remove(int id)
        {
            var post = _dao.BuscarPorId(id); //cuidado, pode retornar null!
            if (post != null)
            {
                _dao.Exclui(post);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // Post/Publica/13918797
        public IActionResult Publica(int id)
        {
            var post = _dao.BuscarPorId(id); //cuidado, pode retornar null!
            if (post != null)
            {
                _dao.Publica(post);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // Post/Categoria/Filmes
        //[Route("Post/Categoria/{categoria}")]
        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            ViewBag.Posts = _dao.FiltrarPorCategoria(categoria);
            return View("Index");
        }
    }

}