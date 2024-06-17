using ControleTarefas.Negocio.Interface.INegocios;
using ControleTarefas.Negocio.Interface.Negocios;
using ControleTarefas.Negocio.Negocios;
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
        }

        private static void InjetarNegocio(IServiceCollection services)
        {
            services.AddScoped<ITarefaNegocio, TarefaNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IAtribuirTarefaNegocio, AtribuirTarefaNegocio>();
        }

        private static void InjetarRepositorio(IServiceCollection services)
        {
            services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ITarefaUsuarioRepositorio, TarefaUsuarioRepositorio>();
        }
    }
}
