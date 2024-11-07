namespace TaskTrack.Models
{
    public class CommentModel
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int TaskID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        public UserModel User { get; set; }  
        public TaskModel Task { get; set; }  
    }
}
