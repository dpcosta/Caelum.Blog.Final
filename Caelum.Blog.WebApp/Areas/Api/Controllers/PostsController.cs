using Caelum.Blog.Negocio;
using Caelum.Blog.WebApp.Dados;
using Microsoft.AspNetCore.Mvc;

namespace Caelum.Blog.WebApp.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Api")]
    public class PostsController : ControllerBase
    {
        private PostDAOComEF _dao;

        public PostsController(PostDAOComEF dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public IActionResult TodosPosts()
        {
            var lista = _dao.Listar();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult PostPorId(int id)
        {
            var post = _dao.BuscarPorId(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult IncluirPost(Post post)
        {
            _dao.Adiciona(post);
            return CreatedAtAction("PostPorId", post); //201
        }

        [HttpPut]
        public IActionResult AtualizaPost(Post post)
        {
            var p = _dao.BuscarPorId(post.Id);
            if (p != null)
            {
                _dao.Atualiza(post);
                return Ok(post);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluiPost(int id)
        {
            var post = _dao.BuscarPorId(id);
            if (post != null)
            {
                _dao.Exclui(post);
                return NoContent(); //204
            }
            return NotFound();
        }
    }
}