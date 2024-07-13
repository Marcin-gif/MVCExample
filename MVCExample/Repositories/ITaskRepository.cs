using MVCExample.Models;

namespace MVCExample.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int id);
        IQueryable<TaskModel> GetAll();
        void Add(TaskModel task);
        void Update(int taskID,TaskModel task);
        void Delete(int id);
    }
}
