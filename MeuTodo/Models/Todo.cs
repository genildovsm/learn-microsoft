using System;

namespace MeuTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
