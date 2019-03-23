using System.Data;
using System.Data.SqlClient;

namespace Caelum.Blog.WebApp.Dados
{
    public class ConnectionFactory //Factory => ObjetoFactory
    {
        public IDbConnection CriaConexao()
        {
            var cnxString = "Server=(localdb)\\MSSQLLocalDB;Database=Blog;Trusted_connection=true";
            IDbConnection cnx = new SqlConnection(cnxString);
            return cnx;
        }
    }
}
