using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Negocio.Negocios;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Repositorio.Repositorios;
using ControleTarefas.WebApi.Middleware;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace ControleTarefas.WebApi
{
    public class Startup
    {
        public Startup()
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            services.AddScoped<ITarefaNegocio, TarefaNegocio>();

            services.AddSwaggerGen(c =>
            {
                c.MapType(typeof(TimeSpan), () => new() { Type = "string", Example = new OpenApiString("00:00:00") });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Controle de Tarefas",
                    Version = "v1",
                    Description = "APIs de estudo em dotnet core 6.",
                    Contact = new() { Name = "Luiz Henrique", Url = new Uri("http://google.com.br") },
                    License = new() { Name = "Private", Url = new Uri("http://google.com.br") },
                    TermsOfService = new Uri("http://google.com.br")
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Tarefas v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseMiddleware<ApiMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}