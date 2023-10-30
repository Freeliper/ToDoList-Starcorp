using Dapper;
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

        public async Task<IEnumerable<Tarefa>> CreateTarefa(Tarefa tarefa)
        {
            using(var con= new SqlConnection(getConnection))
            {
                var sql = "insert into Tarefas (tarefa, conclusao, concluida) values (@tarefa, @conclusao, @concluida)";
                await con.ExecuteAsync(sql, tarefa);

                return await con.QueryAsync<Tarefa>("select * from Tarefas");
            }
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefas()
        {
            using(var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Tarefas where concluida = 'false' order by conclusao asc";
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

        public async Task<IEnumerable<Tarefa>> UpdateTarefa(Tarefa tarefa)
        {
            using( var con= new SqlConnection(getConnection))
            {
                var sql = "update tarefas set concluida = @concluida where id = @id";
                await con.ExecuteAsync(sql, tarefa);

                return await con.QueryAsync<Tarefa>("select * from tarefas");
            }
        }
    }
}
