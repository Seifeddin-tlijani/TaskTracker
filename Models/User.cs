namespace TaskTrack.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } 
        public string Email { get; set; } 
        public string PasswordHash { get; set; } 
        public string Role { get; set; } 
        public DateTime DateCreated { get; set; } 
        public bool IsActive { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public ICollection<Team> TeamUsers { get; set; }

        public ICollection<Comment> Comments { get; set; } 




        public User()
        {
            DateCreated = DateTime.Now; 
            IsActive = true; 
        }
    }
}
