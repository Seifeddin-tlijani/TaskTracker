using System;
using System.Collections.Generic;

namespace TaskTrack.DAL.Entities;

public partial class Project
{
    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int CreatedBy { get; set; }

    public int? TeamId { get; set; }

    public DateTime DateCreated { get; set; }

    public bool IsCompleted { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual Team? Team { get; set; }
}
