using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Caelum.Blog.ConsoleApp
{
    public class Startup
    {
        private int _contador;

        public Task RespondeAloMundo(HttpContext context)
        {
            return context.Response.WriteAsync($"Alô, mundo! {_contador}");
        }

        public Task ContaRequisicoes(HttpContext context, Func<Task> proximoEstagio)
        {
            _contador++;
            return proximoEstagio.Invoke();
        }

        public void PipelineVazio(IApplicationBuilder app)
        {
            //vazio
        }

        public Task RespostaPadrao(HttpContext context)
        {
            //   /posts/novo >> 3 itens "", "posts", "novo"
            var segmentos = context.Request.Path.Value.Split('/');
            var nomeClasse = $"Caelum.Blog.ConsoleApp.{segmentos[1]}Controller";
            var nomeMetodo = segmentos[2];

            //reflection
            var assembly = Assembly.GetExecutingAssembly();
            Type tipo = assembly.GetType(nomeClasse, true, true);
            Object classe = Activator.CreateInstance(tipo);
            MethodInfo method = tipo.GetMethod(nomeMetodo,
                BindingFlags.IgnoreCase | 
                BindingFlags.Public | 
                BindingFlags.Instance);

            RequestDelegate metodo = (RequestDelegate)Delegate.CreateDelegate(
                typeof(RequestDelegate), classe, method);
            return metodo(context);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //cada middleware-estágio do pipeline se traduz em um requestdelegate
            //app.Map("/favicon.ico", PipelineVazio);
            //app.Use(ContaRequisicoes);
            ////app.Run(RespondeAloMundo);
            //app.Run(RespostaPadrao);
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            //app.Run(ctx => ctx.Response.WriteAsync("Delegate anonimo"));
        }
    }
}
