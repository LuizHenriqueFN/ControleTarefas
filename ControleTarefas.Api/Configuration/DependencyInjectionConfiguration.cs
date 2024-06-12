using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Negocio.Negocios;
using ControleTarefas.Repositorio.Interface;
using ControleTarefas.Repositorio;
using ControleTarefas.Repositorio.Interface.IRepositorios;
using ControleTarefas.Repositorio.Repositorios;

namespace ControleTarefas.WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {

        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            InjetarRepositorio(services);
            InjetarNegocio(services);
            services.AddScoped<IGerenciadorTransacao, GerenciadorTransacao>();
        }

        private static void InjetarNegocio(IServiceCollection services)
        {
            services.AddScoped<ITarefaNegocio, TarefaNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
        }

        private static void InjetarRepositorio(IServiceCollection services)
        {
            services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioaRepositorio>();
        }
    }
}
