using System;
using System.Linq;
using System.Collections.Generic;
using Caelum.Blog.Negocio;

namespace Caelum.Blog.WebApp.Dados
{
    public class PostDAOComEF
    {
        private BlogContext _ctx;

        public PostDAOComEF(BlogContext context)
        {
            _ctx = context;
        }

        public IEnumerable<Post> Listar()
        {
            return _ctx.Posts;
        }

        public Post BuscarPorId(int id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == id);
        }

        //SELECT * From Posts WHERE Categoria = 'Filmes'
        public IEnumerable<Post> FiltrarPorCategoria(string categoria)
        {
            return _ctx.Posts.Where(p => p.Categoria.Contains(categoria));
        }

        public void Adiciona(Post post)
        {
            if (post.Autor != null)
            {
                _ctx.Usuarios.Attach(post.Autor);
            }
            _ctx.Posts.Add(post);
            _ctx.SaveChanges();
        }

        public void Exclui(Post post)
        {
            _ctx.Posts.Remove(post);
            _ctx.SaveChanges();
        }

        public void Atualiza(Post post)
        {
            //UPDATE Posts SET col1 = val1, ... WHERE Id = @id
            _ctx.Posts.Update(post);
            _ctx.SaveChanges();
        }

        public void Publica(Post post)
        {
            post.DataPublicacao = DateTime.Now;
            post.Publicado = true;
            this.Atualiza(post);
        }
    }
}

//1- Add-Migration <Rotulo>
//2- Validar o código gerado pelo EF
//3- Se tiver OK: Update-Database
//4- Se não tiver OK: Remove-Migration
