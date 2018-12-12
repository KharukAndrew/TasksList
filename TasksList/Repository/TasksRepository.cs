using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TasksList.Models;
using TasksList.Utils;

namespace TasksList.Repository
{
    public class TasksRepository : ITasksRepository
    {
        public IEnumerable<TaskEntity> GetAll()
        {
            try
            {
                IEnumerable<TaskEntity> tasks;

                using (TasksListDb db = new TasksListDb())
                {
                    tasks = db.TaskEntities.ToList();
                }

                return tasks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaskEntity GetById(int id)
        {
            try
            {
                TaskEntity task;
                using (TasksListDb db = new TasksListDb())
                {
                    task = db.TaskEntities.FirstOrDefault(s => s.Id == id);
                }
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(TaskEntity item)
        {
            try
            {
                using (TasksListDb db = new TasksListDb())
                {
                    db.TaskEntities.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TaskEntity item)
        {
            try
            {
                using (TasksListDb db = new TasksListDb())
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (TasksListDb db = new TasksListDb())
                {
                    TaskEntity task = db.TaskEntities.FirstOrDefault(s => s.Id == id);

                    if (task == null)
                    {
                        throw new NoDataInDatabaseException();
                    }

                    db.TaskEntities.Remove(task);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}