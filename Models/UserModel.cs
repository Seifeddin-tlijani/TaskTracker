namespace TaskTrack.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; } 
        public string Email { get; set; } 
        public string PasswordHash { get; set; } 
        public string Role { get; set; } 
        public DateTime DateCreated { get; set; } 
        public bool IsActive { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }

        public ICollection<TeamModel> TeamUsers { get; set; }

        public ICollection<CommentModel> Comments { get; set; } 




        public UserModel()
        {
            DateCreated = DateTime.Now; 
            IsActive = true; 
        }
    }
}
