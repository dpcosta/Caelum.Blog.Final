using System;
using System.ComponentModel.DataAnnotations;

namespace Caelum.Blog.Negocio
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Você esqueceu de digitar o título.")] //obrigatoriedade
        [StringLength(50, ErrorMessage = "Escreveu mais do que devia!")] //no máximo 50 cars
        public string Titulo { get; set; }

        [Required]
        public string Resumo { get; set; }

        public string Categoria { get; set; }

        //informação de publicação do post
        public bool Publicado { get; set; }
        public DateTime? DataPublicacao { get; set; } //nullable: true

        public Usuario Autor { get; set; }
    }
}
