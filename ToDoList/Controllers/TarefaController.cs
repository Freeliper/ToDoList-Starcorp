using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.TarefaService;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaInterface _tarefaInterface;
        public TarefaController(ITarefaInterface tarefaInterface)
        {
            _tarefaInterface = tarefaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetAllTarefas(bool? concluida)
        {
            IEnumerable<Tarefa> tarefas = await _tarefaInterface.GetAllTarefas(concluida);

            if(!tarefas.Any())
            {
                return NotFound("Nenhum registro localizado!");
            }

            return Ok(tarefas);
        }

        [HttpGet("{tarefaId}")]
        public async Task<ActionResult<Tarefa>> GetTarefaById(int tarefaId)
        {
            Tarefa tarefa = await _tarefaInterface.GetTarefaById(tarefaId);

            if(tarefa == null)
            {
                return NotFound("Registro não localizado!");
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Tarefa>>> CreateTarefa(Tarefa tarefa)
        {
            IEnumerable<Tarefa> tarefas = await _tarefaInterface.CreateTarefa(tarefa);

            return Ok(tarefas);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Tarefa>>> UpdateTarefa(Tarefa tarefa)
        {
            Tarefa registro = await _tarefaInterface.GetTarefaById(tarefa.Id);

            if(registro == null)
            {
                return NotFound("Registro não localizado!");
            }
            IEnumerable<Tarefa> tarefas = await _tarefaInterface.UpdateTarefa(tarefa);
            return Ok(tarefas);
        }
    }
}
