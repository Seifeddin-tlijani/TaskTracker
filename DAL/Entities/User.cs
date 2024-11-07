using System;
using System.Collections.Generic;

namespace TaskTrack.DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Task> TaskAssignedToNavigations { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskCreatedByNavigations { get; set; } = new List<Task>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
