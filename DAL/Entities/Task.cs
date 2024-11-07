using System;
using System.Collections.Generic;

namespace TaskTrack.DAL.Entities;

public partial class Task
{
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Priority { get; set; }

    public int Status { get; set; }

    public int AssignedTo { get; set; }

    public int CreatedBy { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateCompleted { get; set; }

    public int ProjectId { get; set; }

    public virtual User AssignedToNavigation { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
