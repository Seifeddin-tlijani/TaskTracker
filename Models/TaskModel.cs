namespace TaskTrack.Models
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Completed
    }
    public class TaskModel
    {
        public int TaskID { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public TaskPriority Priority { get; set; } 
        public TaskStatus Status { get; set; } 
        public int AssignedTo { get; set; } 
        public int CreatedBy { get; set; }  
        public DateTime DueDate { get; set; } 
        public DateTime DateCreated { get; set; } 
        public DateTime? DateCompleted { get; set; }

        public int ProjectID { get; set; }

        public ProjectModel Project { get; set; } 





    }
}
