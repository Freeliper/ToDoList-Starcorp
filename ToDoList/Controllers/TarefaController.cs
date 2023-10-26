﻿using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetAllTarefas()
        {
            IEnumerable<Tarefa> tarefas = await _tarefaInterface.GetAllTarefas();

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


    }
}
