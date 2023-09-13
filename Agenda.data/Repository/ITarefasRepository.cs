using Agenda.data.Models.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda.data.Repository
{
    public interface ITarefasRepository
    {
        Task<bool> CriarAsync(Tarefas tarefas);

        Task<bool> EditarAsync(Tarefas tarefas);

        Task<bool> DeletarAsync(int id);

        Task<IEnumerable <Tarefas>> ListarAsync();

        Task<Tarefas?> GetTarefasAsync(int id);

    }
}