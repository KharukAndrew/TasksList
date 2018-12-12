using Ninject.Modules;
using TasksList.Repository;

namespace TasksList.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ITasksRepository>().To<TasksRepository>();
        }
    }
}