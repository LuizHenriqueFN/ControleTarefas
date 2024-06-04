
using ControleTarefas.Entidade.DTO;
using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Repositorio.Interface.IRepositorios;

namespace ControleTarefas.Repositorio.Repositorios
{
    public class UsuarioaRepositorio : IUsuarioRepositorio
    {
        private static List<Usuario> Usuario { get; set; } = new();

        public List<UsuarioDTO> ObterUsuarios(List<string> emails)
        {
            return Usuario.Where(usuario => emails.Contains(usuario.Email.ToUpper()))
                          .OrderBy(usuario => usuario.Nome)
                          .Distinct()
                          .Select(usuario => new UsuarioDTO
                          {
                              Nome = usuario.Nome,
                              Email = usuario.Email,
                              DataAtualizacao = usuario.DataAtualizacao,
                              Perfil = usuario.Perfil
                          })
                          .ToList();
        }

        public List<UsuarioDTO> ObterTodosUsuarios()
        {
            return Usuario.OrderBy(usuario => usuario.Nome)
                          .Distinct()
                          .Select(usuario => new UsuarioDTO
                          {
                              Nome = usuario.Nome,
                              Email = usuario.Email,
                              DataAtualizacao = usuario.DataAtualizacao,
                              Perfil = usuario.Perfil
                          })
                          .ToList();
        }

        public void DeletarUsuario(Usuario usuario)
        {
            Usuario.Remove(usuario);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            Usuario.Add(usuario);
        }

        public Usuario? ObterUsuario(string email)
        {
            return Usuario.Find(e => e.Email.ToLower() == email.ToLower());
        }
    }
}
