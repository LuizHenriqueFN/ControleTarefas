using ControleTarefas.Entidade.Entidades;
using ControleTarefas.Entidade.Model;
using ControleTarefas.Utilitarios.Excepetions;
using ControleTarefas.Utilitarios.Messages;

namespace ControleTarefas.Validador.Manual
{
    public static class CadastroTarefaValidador
    {
        public static void Validar(CadastroTarefaModel novaTarefa, Tarefa? tarefa)
        {
            var erros = new List<string>();

            if (tarefa != null)
            {
                erros.Add(string.Format(BusinessMessages.RegistroExistente, "Título"));
            }
            else
            {
                if (string.IsNullOrEmpty(novaTarefa.Titulo))
                {
                    erros.Add(string.Format(BusinessMessages.CampoObrigatorio, "Título"));
                }
                else
                {
                    if (novaTarefa.Titulo.Length < 5)
                        erros.Add(string.Format(BusinessMessages.CampoTamanhoMinimo, "Título", 5));
                    if (novaTarefa.Titulo.Length > 50)
                        erros.Add(string.Format(BusinessMessages.CampoTamanhoMaximo, "Título", 50));
                }

                if (erros.Any())
                {
                    throw new BusinessListException(erros);
                }
            }
        }
    }
}
