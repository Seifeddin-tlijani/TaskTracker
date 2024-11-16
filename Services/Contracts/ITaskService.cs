namespace TaskTrack.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<DAL.Entities.Task>> GetAllTasksAsync();
        System.Threading.Tasks.Task AddTaskAsync(DAL.Entities.Task task);
        System.Threading.Tasks.Task UpdateTaskAsync(DAL.Entities.Task task);             // Task from System.Threading.Tasks
        System.Threading.Tasks.Task DeleteTaskAsync(int id);                // Task from System.Threading.Tasks
    }
}
