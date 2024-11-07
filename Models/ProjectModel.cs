namespace TaskTrack.Models
{
    public class ProjectModel
    {

        public int ProjectID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public int CreatedBy { get; set; }
        public int? TeamID { get; set; } 
        public DateTime DateCreated { get; set; } 
        public bool IsCompleted { get; set; }

        public ICollection<TaskModel> Tasks { get; set; } 
        public ICollection<TeamModel> TeamProjects { get; set; } 

        public ProjectModel()
        {
            DateCreated = DateTime.Now; 
            IsCompleted = false; 
        }
    }
}
