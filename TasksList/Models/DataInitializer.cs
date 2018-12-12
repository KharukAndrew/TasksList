using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TasksList.Models
{
    public class DataInitializer : DropCreateDatabaseAlways<TasksListDb>
    {
        protected override void Seed(TasksListDb db)
        {
            db.TaskEntities.AddRange(new List<TaskEntity>
            {
                new TaskEntity{Date =DateTime.Now.AddDays(-1), Header = "Test", Text = "This is text forthe test task", IsDone = false }
            });

            base.Seed(db);
        }
    }
}