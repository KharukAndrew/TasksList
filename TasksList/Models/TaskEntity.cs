using System;
using System.ComponentModel.DataAnnotations;

namespace TasksList.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter Header")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Please enter Text")]
        [DataType(DataType.Text)]
        public string Text { get; set; }
        public bool IsDone { get; set; }
    }
}