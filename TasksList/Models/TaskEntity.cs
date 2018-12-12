using System;

namespace TasksList.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
    }
}