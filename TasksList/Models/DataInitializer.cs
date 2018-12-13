using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TasksList.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<TasksListDb>
    {
        protected override void Seed(TasksListDb db)
        {
            db.TaskEntities.AddRange(new List<TaskEntity>
            {
                new TaskEntity{Date =DateTime.Now.AddDays(-5), Header = "One task", Text = "This is text for the one task", IsDone = true },
                new TaskEntity{Date =DateTime.Now.AddDays(-4), Header = "Two task", Text = "This is text for the two task", IsDone = false },
                new TaskEntity{Date =DateTime.Now.AddDays(-3), Header = "Three task", Text = "This is text for the three task", IsDone = true },
                new TaskEntity{Date =DateTime.Now.AddDays(-2), Header = "Four task", Text = "This is text for the four task", IsDone = false },
                new TaskEntity{Date =DateTime.Now.AddDays(-1), Header = "Five task", Text = "This is text for the five task", IsDone = false }
            });

            base.Seed(db);
        }
    }
}