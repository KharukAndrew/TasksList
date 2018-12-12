using System.Collections.Generic;
using TasksList.Models;

namespace TasksList.Repository
{
    public interface ITasksRepository
    {
        IEnumerable<TaskEntity> GetAll();
        TaskEntity GetById(int id);
        void Create(TaskEntity item);
        void Update(TaskEntity item);
        void Delete(int id);
    }
}
