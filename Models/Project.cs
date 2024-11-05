namespace TaskTrack.Models
{
    public class Project
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

        public ICollection<Task> Tasks { get; set; } 
        public ICollection<Team> TeamProjects { get; set; } 

        public Project()
        {
            DateCreated = DateTime.Now; 
            IsCompleted = false; 
        }
    }
}
