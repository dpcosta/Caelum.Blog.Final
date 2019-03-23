using Microsoft.EntityFrameworkCore;
using Caelum.Blog.Negocio;

namespace Caelum.Blog.WebApp.Dados
{
    public class BlogContext : DbContext
    {
        //nome dessa propriedade determina o nome da tabela
        public DbSet<Post> Posts { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
    }
}
