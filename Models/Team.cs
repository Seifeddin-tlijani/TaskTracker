namespace TaskTrack.Models
{
    public class Team
    {

        public int TeamID { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public DateTime DateCreated { get; set; } 
        public int CreatedBy { get; set; } 

        public Team()
        {
            DateCreated = DateTime.Now; 
        }

    }
}
