﻿using ControleTarefas.Entidade.DTO;

namespace ControleTarefas.Negocio.Interface.INegocios
{
    public interface ITarefaNegocio
    {
        List<TarefaDTO> ObterTarefas(List<string>? tarefas);
        
        List<TarefaDTO> AdicionarTarefa(string novaTarefa);

        List<TarefaDTO> AlterarTarefa(string nomeTarefa, string novoNomeTarefa);
       
        List<TarefaDTO> DeletarTarefa(string nomeTarefa);
    }
}