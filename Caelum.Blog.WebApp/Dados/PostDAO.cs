using System;
using System.Data;
using System.Collections.Generic;
using Caelum.Blog.Negocio;
using System.Linq.Expressions;

namespace Caelum.Blog.WebApp.Dados
{
    //CRUD => Create, Restore, Update, Delete de POSTS
    //DAO => Data Access Object PostDAO
    //SRP => Single Responsibility Principle
    public class PostDAO
    {
        private IDbConnection _cnx;

        public PostDAO(IDbConnection cnx)
        {
            _cnx = cnx;
        }

        public IEnumerable<Post> Listar()
        {
            var posts = new List<Post>();

            using (_cnx)
            using (IDbCommand cmd = _cnx.CreateCommand())
            {
                _cnx.Open();
                cmd.CommandText = "SELECT * FROM Posts";
                using (IDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        var post = new Post();
                        post.Id = Convert.ToInt32(leitor["Id"]);
                        post.Titulo = Convert.ToString(leitor["Titulo"]);
                        post.Resumo = Convert.ToString(leitor["Resumo"]);
                        post.Categoria = Convert.ToString(leitor["Categoria"]);
                        posts.Add(post);
                    }
                }
            }
            return posts;
        }

        private void AddParameter(IDbCommand cmd, string paramName, object paramValue)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
        }

        public void Adiciona(Post post)
        {
            using (_cnx)
            using (IDbCommand cmd = _cnx.CreateCommand())
            {
                _cnx.Open();
                cmd.CommandText =
                    "INSERT INTO Posts (Titulo, Resumo, Categoria)" +
                    $" VALUES (@titulo, @resumo, @categ)";

                //ADO.NET >> parâmetros
                AddParameter(cmd, "titulo", post.Titulo);
                AddParameter(cmd, "resumo", post.Resumo);
                AddParameter(cmd, "categ", post.Categoria);

                cmd.ExecuteNonQuery();
            }
        }

        public void Exclui(int id)
        {
            using (_cnx)
            using (IDbCommand cmd = _cnx.CreateCommand())
            {
                _cnx.Open();
                cmd.CommandText = $"DELETE FROM Posts WHERE Id = @id";
                AddParameter(cmd, "id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

/*
 * 
SELECT [col1, col2, .., colN] FROM [tabela]

INSERT INTO [tabela] ( [col1, col2, .., colN] ) VALUES ( [val1, val2, .., colN] )

DELETE FROM [tabela] WHERE pk1 = val1

UPDATE [tabela] SET ... WHERE ID =


    [tabela] >>> nome da classe 
    [coluna] >>> nome da propriedade
    [chave primária] >>>> ???

    Entity Framework Core >> EF6 >> EF Core 1 >> EF Core 2.2
    NHibernate
    ...
     
     */
