using TaskTrack.DAL.Entities;

namespace TaskTrack.Services.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task<Project> DeleteProjectAsync(int id);
    }
}
