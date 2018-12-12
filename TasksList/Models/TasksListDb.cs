namespace TasksList.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TasksListDb : DbContext
    {
        public TasksListDb()
            : base("name=TasksListDb")
        {
        }

        public virtual DbSet<TaskEntity> TaskEntities { get; set; }
    }
}