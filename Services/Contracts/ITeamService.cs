using TaskTrack.DAL.Entities;

namespace TaskTrack.Services.Contracts
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();     
        Task<Team> GetTeamByIdAsync(int id);            
        System.Threading.Tasks.Task AddTeamAsync(Team team);
        System.Threading.Tasks.Task UpdateTeamAsync(Team team);
        System.Threading.Tasks.Task DeleteTeamAsync(int id);                    
    }
}
