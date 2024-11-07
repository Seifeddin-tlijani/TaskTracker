using System;
using System.Collections.Generic;

namespace TaskTrack.DAL.Entities;

public partial class Team
{
    public int TeamId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
