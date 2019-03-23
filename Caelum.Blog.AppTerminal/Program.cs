using Caelum.Blog.Negocio;
using System;
using System.Collections.Generic;

namespace Caelum.Blog.AppTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Titulo = "Harry Potter I",
                    Resumo = "Pedra Filosofal",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Harry Potter I",
                    Resumo = "Pedra Filosofal",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Harry Potter II",
                    Resumo = "Câmara Secreta",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Harry Potter III",
                    Resumo = "Prisioneiro de Askaban",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Game of Thrones",
                    Resumo = "Winter is Coming",
                    Categoria = "Séries"
                },
                new Post
                {
                    Titulo = "Stranger Things",
                    Resumo = "Série da Netflix",
                    Categoria = "Séries"
                },
                new Post
                {
                    Titulo = "Refactoring",
                    Resumo = "Improving design of existing code",
                    Categoria = "Livros"
                },
            };


            ExecutaAcaoEmListaFiltradaDePosts(
                posts,
                post => post.Titulo == "Filmes",
                post => Console.WriteLine(post.Titulo)
            );

            ExecutaAcaoEmListaFiltradaDePosts(
                posts,
                PostEhDaCategoriaFilmes,
                AdicionaNoCorpoEmail);
        }

        private static void ExecutaAcaoEmListaFiltradaDePosts(
            IEnumerable<Post> posts,
            Func<Post, bool> condicao,
            Action<Post> acao)
        {
            foreach (var post in posts)
            {
                if (condicao(post))
                {
                    acao(post);
                }
            }
        }

        private static bool PostEhDaCategoriaFilmes(Post post)
        {
            return post.Categoria == "Filmes";
        }

        private static void AdicionaNoCorpoEmail(Post post)
        {

        }

        private static void EscrevePostNoTerminal(Post post)
        {
            Console.WriteLine(post.Titulo);
        }
    }
}
