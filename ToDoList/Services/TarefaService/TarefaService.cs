﻿using Dapper;
using System.Data.SqlClient;
using ToDoList.Models;

namespace ToDoList.Services.TarefaService
{
    public class TarefaService : ITarefaInterface
    {

        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public TarefaService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public Task<IEnumerable<Tarefa>> CreateTarefa(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefas()
        {
            using(var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM Tarefas ORDER BY conclusao ASC";
                return await con.QueryAsync<Tarefa>(sql);
            }
        }

        public async Task<Tarefa> GetTarefaById(int tarefaId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Tarefas where id= @Id";
                return await con.QueryFirstOrDefaultAsync<Tarefa>(sql, new { Id = tarefaId });
            }
        }

        public Task<IEnumerable<Tarefa>> UpdateTarefa(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }
    }
}
