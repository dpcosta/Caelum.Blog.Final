using Caelum.Blog.Negocio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Blog.ConsoleApp
{
    public class PostsController
    {
        public Task Detalhe(HttpContext context)
        {
            return context.Response.WriteAsync("Detalhe do post");
        }

        public Task ListaPosts(HttpContext context)
        {
            Post p1 = new Post
            {
                Titulo = "Harry Potter I",
                Resumo = "Pedra Filosofal",
                Categoria = "Filmes"
            };

            Post p2 = new Post
            {
                Titulo = "Harry Potter II",
                Resumo = "Câmara Secreta",
                Categoria = "Filmes"
            };

            Post p3 = new Post
            {
                Titulo = "Harry Potter III",
                Resumo = "Prisioneiro",
                Categoria = "Livros"
            };

            Post p4 = new Post
            {
                Titulo = "Harry Potter IV",
                Resumo = "Cálice de Fogo",
                Categoria = "Livros"
            };

            Post p5 = new Post
            {
                Titulo = "Game of Thrones",
                Resumo = "Winter is Coming",
                Categoria = "Séries"
            };

            List<Post> posts = new List<Post>
            {
                p1, p2, p3, p4, p5
            };

            var listaComoString = new StringBuilder();
            foreach (var post in posts)
            {
                listaComoString.Append(post.Titulo);
            }
            return context.Response.WriteAsync(listaComoString.ToString());
        }
    }
}
