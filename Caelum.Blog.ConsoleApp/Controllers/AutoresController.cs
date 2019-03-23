using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Blog.ConsoleApp
{
    public class AutoresController
    {
        public string Detalhe()
        {
            return @"
                <html>
                    <body>
                        <h1>Detalhe do Autor</h1>
                    </body>
                </html>
            ";
        }
    }
}
