using Microsoft.EntityFrameworkCore;
using TaskTrack.DAL;
using TaskTrack.DAL.Entities;
using TaskTrack.Services.Contracts;

namespace TaskTrack.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskTrackDbContext _context;

        public TaskService()
        {
        }

        public TaskService(TaskTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DAL.Entities.Task>> GetAllTasksAsync()
        {
            try
            {
                return await _context.Tasks.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while retrieving tasks from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving tasks.", ex);
            }
        }

        public async System.Threading.Tasks.Task AddTaskAsync(DAL.Entities.Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while adding the task to the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the task.", ex);
            }
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(DAL.Entities.Task task)
        {
            try
            {
                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the task.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the task in the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the task.", ex);
            }
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    throw new KeyNotFoundException($"Task with ID {id} not found.");
                }

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException ex)
            {
                throw ex; 
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the task from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while deleting the task.", ex);
            }
        }
    }
}
