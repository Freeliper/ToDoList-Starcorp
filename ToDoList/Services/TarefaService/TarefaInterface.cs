using ToDoList.Models;

namespace ToDoList.Services.TarefaService
{
    public interface ITarefaInterface
    {
        Task<IEnumerable<Tarefa>> GetAllTarefas();
        Task<Tarefa> GetTarefaById(int tarefaId);
        Task<IEnumerable<Tarefa>> CreateTarefa(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> UpdateTarefa(Tarefa tarefa);
    }
}
