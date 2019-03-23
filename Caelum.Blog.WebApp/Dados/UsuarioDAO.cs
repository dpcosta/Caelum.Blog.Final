using Caelum.Blog.Negocio;
using System.Linq;

namespace Caelum.Blog.WebApp.Dados
{
    public class UsuarioDAO
    {
        private BlogContext _ctx;

        public UsuarioDAO(BlogContext context)
        {
            _ctx = context;
        }

        public Usuario Busca(string login, string senha)
        {
            return _ctx.Usuarios
                .FirstOrDefault(u => u.Login == login && 
                    u.Password == senha);
        }
    }
}
