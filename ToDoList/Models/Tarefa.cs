namespace ToDoList.Models
{
    public class Tarefa
    {

        public int Id { get; set; }
        public string tarefa { get; set; } = string.Empty;
        public DateTime conclusao { get; set; } 
        public bool concluida { get; set; } = false;

    }
}
